using UnityEngine;
using System.Collections;

public class CreatureController : MonoBehaviour {
	public float speed = 10.0f;
	public bool isMoving = false;
	public bool isReady = true;

	Vector3 target;
	float distancePerSecond;

	void Start() {
		isReady = tag != "Player";
	}

	void Update() {
		if (tag == "Player")
			HandleUserInput();

		Move();
	}
	void StepBy(int x, int y) {
		if (x == 0 && y == 0)
			return;

		target = transform.position + new Vector3(x, y, 0);
		distancePerSecond = new Vector3(x, y, 0).magnitude / 1 * speed;
		isMoving = true;
		isReady = false;
	}

	void Move() {
		if (!isMoving)
			return;

		var next = Vector3.MoveTowards(transform.position, target, distancePerSecond * Time.deltaTime);
		if (Vector3.Distance(next, target) < 0.001f) {
			transform.position = target;
			isMoving = false;
			isReady = tag != "Player";
		} else {
			transform.position = next;
		}
	}

	void HandleUserInput() {
		if (isMoving)
			return;
		
		var mx = (int)Input.GetAxisRaw("Horizontal");
		var my = (int)Input.GetAxisRaw("Vertical");

		if (mx == 0 && my == 0)
			return;

		StepBy(mx, my);
		isReady = true;
	}
	
	public void DoAi() {
		if (tag == "Player")
			return;
		
		StepBy(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2));
	}
}
