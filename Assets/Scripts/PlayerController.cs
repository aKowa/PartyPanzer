using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public Vector3 initPosition;
	[HideInInspector]
	public Quaternion initRotation;

	void Start ()
	{
		initPosition = this.transform.position;
		initRotation = this.transform.rotation;

		if (this.tag == "Player1")
		{
			Player.one = this;
		}
		else if (this.tag == "Player2")
		{
			Player.two = this;
		}
	}

	public void Reset()
	{
		this.transform.position = this.initPosition;
		this.transform.rotation = this.initRotation;
	}
}
