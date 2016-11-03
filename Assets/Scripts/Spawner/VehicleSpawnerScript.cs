using UnityEngine;
using System.Collections;

public class VehicleSpawnerScript : MonoBehaviour {

	[SerializeField]
	private Transform[] vehicleTransform;

	[SerializeField]
	private Transform[] spawnPoints;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 1,7);
	}
	
	// Update is called once per frame
	void Spawn () {
		int playerCount = GameManager.players.Count;
		int randVehicle = Random.Range (0, vehicleTransform.Length);
		int randSpawn = Random.Range (0, spawnPoints.Length);
		if (playerCount >= 1)
			Instantiate (vehicleTransform [randVehicle], new Vector3(spawnPoints [randSpawn].position.x, 0.0f, spawnPoints [randSpawn].position.z), spawnPoints [randSpawn].rotation);	
	}
}
