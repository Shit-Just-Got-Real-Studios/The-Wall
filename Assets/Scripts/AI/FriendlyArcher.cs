using UnityEngine;
using System.Collections;

public class FriendlyArcher : MonoBehaviour {

	[SerializeField]
	private GameObject bow;
	private GameObject enemyTagged = null;

	void SearchTarget () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("ZombieBOT");
		if (enemies.Length > 0) {
			int randIndex = Random.Range (0, enemies.Length);
			enemyTagged = enemies [randIndex];
		}
	}

	void AttackEnemy () { 
		transform.LookAt (enemyTagged.transform);
		transform.rotation = Quaternion.Euler (0f, transform.localEulerAngles.y , 0f);
		FriendlyArcherBowScript fab = bow.GetComponent<FriendlyArcherBowScript> ();
		fab.Attack (enemyTagged);
	}

	void Awake () {
		SearchTarget ();
	}

	void Start () {

	}

	void Update () {
		if (enemyTagged == null)
			SearchTarget ();
		else if (enemyTagged.tag == "ZombieBOT")
			AttackEnemy ();
	}
}
