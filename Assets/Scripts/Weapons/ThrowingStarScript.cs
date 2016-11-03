using UnityEngine;
using System.Collections;

public class ThrowingStarScript : MonoBehaviour {


	[SerializeField]
	private Transform spawnTransform;

	[SerializeField]
	private GameObject throwingStar;

	private bool shot = false;
	void Update () {
		if (Input.GetMouseButtonDown(0) && !shot) {
			shot = true;
		}
		if (shot) {
			Instantiate (throwingStar, spawnTransform.position, spawnTransform.rotation);
			shot = false;
		}
	}
}
