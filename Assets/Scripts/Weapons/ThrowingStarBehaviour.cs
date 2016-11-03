using UnityEngine;
using System.Collections;

public class ThrowingStarBehaviour : MonoBehaviour {

	[SerializeField]
	private float speed;
	void Update () {
		transform.Rotate (new Vector3 (0f, 0f, 20f));
		transform.Translate (new Vector3 (speed * Time.fixedDeltaTime, 0f,  0f));
	}
}
