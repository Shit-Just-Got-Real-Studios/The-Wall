using UnityEngine;
using System.Collections;

public class FriendlyArcherBowScript : MonoBehaviour {

	[SerializeField]
	private GameObject arrow;

	[SerializeField]
	private Transform spawnTransform;

	public void Attack (GameObject enemyTagged) {
		transform.LookAt (enemyTagged.transform);
	}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("ShootArrow",3,1);
	}

	void ShootArrow () {
		Instantiate (arrow, spawnTransform.position, spawnTransform.rotation);
	}

}
