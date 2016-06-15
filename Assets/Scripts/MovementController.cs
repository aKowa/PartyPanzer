using UnityEngine;
using System.Collections;

[RequireComponent( typeof(Rigidbody2D), typeof(Animator), typeof(HitController) )]
public class MovementController : MonoBehaviour
{
    public float MoveSpeed = 3F;
    public float RotateSpeed = 60F;
	private Rigidbody2D _rigid;
	private Animator _anim;
	private HitController _hit;

	private void Awake()
	{
		_rigid = this.GetComponentInChildren<Rigidbody2D>();
		_anim = this.GetComponent<Animator>();
		_hit = this.GetComponent<HitController>();
	}

	private void Update()
	{
		if (_hit.WasHit) return;

		var left = false;
		var right = false;

		switch (this.tag)
		{
			case "Player1":
				left = InputController.Player1Left;
				right = InputController.Player1Right;
				break;
			case "Player2":
				left = InputController.Player2Left;
				right = InputController.Player2Right;
				break;
		}

		_anim.SetBool("LeftTread", left);
		_anim.SetBool("RightTread", right);

		if (left && right)
		{
			_rigid.angularVelocity = 0;
			_rigid.velocity = (Vector2) this.transform.up*MoveSpeed;
			return;
		}

		if (left || right)
		{
			_rigid.velocity = Vector2.zero;
			_rigid.angularVelocity = left ? RotateSpeed : RotateSpeed*-1;
			return;
		}

		ResetMovement();
	}

	public void ResetMovement()
	{
		_rigid.velocity = Vector2.zero;
		_rigid.angularVelocity = 0;
	}

	public void ResetAll()
	{
		ResetMovement();
		StopCoroutine(_hit.BlockMovementForSec());
		_hit.WasHit = false;
	}
}
