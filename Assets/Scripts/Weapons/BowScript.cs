using UnityEngine;
using System.Collections;

public class BowScript : MonoBehaviour {

	[SerializeField]
	private Transform spawnTransform;

	[SerializeField]
	private GameObject arrow;

	private bool shot = false;

	private ArrowScript ascr;
	void Start() {
		ascr = arrow.GetComponent<ArrowScript> ();
	}

	void Update () {
		if (!ascr.shot) {
			GameObject clone = (GameObject)Instantiate (arrow, spawnTransform.position, spawnTransform.rotation);
			clone.transform.SetParent (transform);
			ascr.shot = true;
		}
		if (!shot) {
			arrow.transform.position = spawnTransform.position;
		}
		if (Input.GetMouseButtonDown(0) && !shot) {
			shot = true;
		}
		if (shot) {
			ascr.temp = 1;
			shot = false;
		}
	}
}
