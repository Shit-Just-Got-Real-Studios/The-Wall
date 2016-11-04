using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {
	[SerializeField]
	private GameObject zombie;

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
			Instantiate (zombie, spawnPoints [randSpawn].position, spawnPoints [randSpawn].rotation);
			counter += 1;
		}
	}
}
