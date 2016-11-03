using UnityEngine;
using System.Collections.Generic;

public class AIVehicleScript : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private int HealthPacket;

	[SerializeField]
	private float angle;

	[SerializeField]
	private GameObject explosion;
	public GameObject currentNode;
	private int randIndex = Random.Range (0, 2);
	private int counter = 0;
	void Start () {
		GameObject[] nodes = GameObject.FindGameObjectsWithTag ("PathNodes");
		foreach (GameObject node in nodes) {
			Node _node = node.GetComponent<Node> ();
			if (_node.nodeLevel == 0) {
				currentNode = (node);
				if (counter == randIndex) {
					break;
				}
				counter++;
			}
		}
	}

	void Update () {
		Node _node = currentNode.GetComponent<Node> ();
		if (_node.nodeLevel != -1) {
			transform.LookAt (currentNode.transform);
			if (Vector3.Distance (transform.position, currentNode.transform.position) <= 3.0f) {
				Node curNode = currentNode.GetComponent<Node> ();
				curNode.ChooseNextNode (gameObject);
			}
			transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime);
			transform.Rotate (new Vector3 (0, angle, 0));
		}
	}

	void Destroy () {
		GameObject _gfx = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (_gfx, 3f);
		Destroy (gameObject);
	}
}
