using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	public int nodeLevel;
	public int nextNode;

	[SerializeField]
	private GameObject[] neighbourNodes;
	public void ChooseNextNode (GameObject vehicle) {
		nextNode = Random.Range (0, neighbourNodes.Length);
		AIVehicleScript vScript = vehicle.GetComponent<AIVehicleScript> ();
		vScript.currentNode = neighbourNodes[nextNode];
	}
}
