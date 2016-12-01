using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	[SerializeField]
	private Transform startPoint;

	[SerializeField]
	private Transform endPoint;

	[SerializeField]
	private float speed;

	private bool isGoingUp = true;
	private bool travelling = false;
	void Update () {
		if (isGoingUp) {
			if (Input.GetKeyDown(KeyCode.E)) {
				travelling = true;
			}
			if (travelling) {
				//transform.LookAt (endPoint);
				if (Vector3.Distance (transform.position, endPoint.position) >= 0.0f)
					transform.Translate (new Vector3 (0f, speed * Time.fixedDeltaTime, 0f));
				else {
					
					isGoingUp = false;
					travelling = false;
				}
			}
		} else {
			if (Input.GetKeyDown (KeyCode.E)) {
				travelling = true;
			}
			if (travelling) {
				//transform.LookAt (startPoint);
				if (Vector3.Distance (transform.position, startPoint.position) >= 0.0f)
					transform.Translate (new Vector3 (0f, -speed * Time.fixedDeltaTime, 0f));
				else {
					isGoingUp = true;
					travelling = false;
				}
			}
		}
	}
}
