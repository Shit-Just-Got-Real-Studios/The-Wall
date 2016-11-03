using UnityEngine;
using System.Collections;

public class WeaponSwitchScript : MonoBehaviour {

	private int weaponIndex;

	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f)
			weaponIndex += 1;
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0f)
			weaponIndex -= 1;
		for (int i = 0; i < transform.childCount; i++) {
			if (i != weaponIndex)
				transform.GetChild (i).gameObject.SetActive (false);
		}
		if (weaponIndex < 0)
			weaponIndex = transform.childCount - 1;
		else if (weaponIndex >= transform.childCount)
			weaponIndex = 0;
		if (!transform.GetChild(weaponIndex).gameObject.activeSelf)
			transform.GetChild (weaponIndex).gameObject.SetActive (true);
	}
}
