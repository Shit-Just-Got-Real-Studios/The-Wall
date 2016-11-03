using UnityEngine;
using System.Collections;

public class BowScript : MonoBehaviour {

	[SerializeField]
	private Transform spawnTransform;

	[SerializeField]
	private GameObject arrow;

	private bool shot = false;
	void Update () {
		if (Input.GetMouseButtonDown(0) && !shot) {
			shot = true;
		}
		if (shot) {
			Instantiate (arrow, spawnTransform.position, spawnTransform.rotation);
			shot = false;
		}
	}
}
