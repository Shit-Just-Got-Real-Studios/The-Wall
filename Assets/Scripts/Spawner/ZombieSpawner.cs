using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {
	[SerializeField]
	private Transform zombie;

	[SerializeField]
	private Transform[] spawnPoints;
	// Use this for initialization
	private int counter = 0;
	void Start () {
		if (counter < 500) {
			InvokeRepeating ("Spawn", 2, 2);
		}
	}

	
	void Spawn () {
		int randSpawn = Random.Range (0, spawnPoints.Length);
		int playerCount = GameManager.players.Count;
		if (playerCount >= 1) {
			Instantiate (zombie, new Vector3 (spawnPoints [randSpawn].position.x, 0.0f, spawnPoints [randSpawn].position.z), spawnPoints [randSpawn].rotation);
			counter += 1;
		}
	}
}
