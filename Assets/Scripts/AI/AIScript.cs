using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {
//	[SerializeField]
//	private int HealthPacket = 100;

	[SerializeField]
	private float speed = 5f;

	public Animation anim;

	private Player player;
	private string playerName;
	void Awake () {
		playerName = "Player " + Random.Range (1, GameManager.players.Count + 1).ToString ();
		anim ["walk"].speed = 2.0f;
	}
	void Update () {
		if (GameManager.GetPlayer (playerName) != null)
			player = GameManager.GetPlayer (playerName);

		if (Vector3.Distance (transform.position, player.gameObject.transform.position) <= 4.0f) {
			gameObject.GetComponent<Animation> ().CrossFade ("attack");
		} else {
			transform.LookAt (player.gameObject.transform.position);
			transform.GetComponent<Animation> ().CrossFade ("walk");
			transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime);
		}
	}
}
