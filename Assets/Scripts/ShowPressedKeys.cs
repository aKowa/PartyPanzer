using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPressedKeys : MonoBehaviour {

	private Text text;

	void Start()
	{
		text = this.GetComponent<Text>();
	}

	void Update () {
		foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
			if(Input.GetKey(vKey)){
				Debug.Log(vKey.ToString());
				text.text = vKey.ToString();
			}
		}
	}
}
