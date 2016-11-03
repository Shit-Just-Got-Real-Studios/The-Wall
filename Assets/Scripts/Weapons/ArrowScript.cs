using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	[SerializeField]
	private float speed;

	void Start () {
		
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "ZombieBOT")
			Destroy (col.gameObject);
		else if (col.gameObject.tag == "AIVehicle") {
			col.gameObject.SendMessage ("Destroy", SendMessageOptions.DontRequireReceiver);
		}
	}
	void Update () {
		transform.Translate (new Vector3 (0, -speed * Time.fixedDeltaTime, 0));
		if (transform.position.y <= -1.0f)
			Destroy (gameObject);
	}
}
