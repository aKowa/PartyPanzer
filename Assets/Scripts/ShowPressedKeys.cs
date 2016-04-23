using UnityEngine;
using System.Collections;

public class ShowPressedKeys : MonoBehaviour {

	void Update () {
		foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
			if(Input.GetKey(vKey)){
				Debug.Log(vKey.ToString());
			}
		}
	}
}
