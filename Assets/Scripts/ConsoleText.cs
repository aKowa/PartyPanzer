using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConsoleText : MonoBehaviour
{
	private Text text;
	
	void Start()
	{
		this.text = this.GetComponent<Text>();
	}

	void Update () {
		text.text = Logger.output;
	}
}
