using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public Vector3 InitPosition;
	[HideInInspector]
	public Quaternion InitRotation;

	private MovementController _movement;

	private void Start ()
	{
		InitPosition = this.transform.position;
		InitRotation = this.transform.rotation;
		_movement = this.GetComponent<MovementController>();

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
		_movement.ResetAll();
		this.transform.position = this.InitPosition;
		this.transform.rotation = this.InitRotation;
	}
}
