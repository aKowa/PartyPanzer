using UnityEngine;
using System.Collections;

public class DemoButtons : MonoBehaviour {

	[Tooltip("First Try at animating Buttons")]



		public float speed = 1f;

	void Start () {
		
		StartCoroutine ( ButtonPresses () );
	}

	IEnumerator ButtonPresses ()
	{

		ButtonLeftB.active = false;
		ButtonRightB.active = true;
		yield return new WaitForSeconds(2);
		ButtonLeftB.active = true;
		ButtonRightB.active = false;
		yield return new WaitForSeconds(2);

		StartCoroutine ( ButtonPresses () );
	}
}
