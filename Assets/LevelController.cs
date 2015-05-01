using UnityEngine;
using System.Collections;
using System.Linq;

public class LevelController : MonoBehaviour {
	public CreatureController[] creatures;

	void Update () {
		if (creatures.Any(c => !c.isReady))
			return;

		foreach (var c in creatures)
			c.DoAi();
	}
}
