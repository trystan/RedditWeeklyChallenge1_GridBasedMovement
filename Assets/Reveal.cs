using UnityEngine;
using System.Collections;

public class Reveal : MonoBehaviour {
	int index = 0;
	private string chars = "abcdefghijklmnopqrstuvwxyz";

	// Read the DawmLike_3 README for why this exists....

	void Update () {
		if (index >= chars.Length)
			return;

		var nextLetter = chars[index];

		if (Input.GetKey(nextLetter + ""))
			index++;

		if (index == chars.Length) {
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
