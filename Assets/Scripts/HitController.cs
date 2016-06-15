using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(MovementController))]
public class HitController : MonoBehaviour
{
	public float PenaltyTime = 1F;
	public float PushForce = 1F;
	public float Torque = 50f;
	public float TorqueAdd = 10f;
	[HideInInspector]
	public bool WasHit;
	private Rigidbody2D _rigid;

	public void Awake ()
	{
		_rigid = this.GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D ( Collider2D other )
	{
		if (other.tag != "Missile" || WasHit) return;
		StartCoroutine(BlockMovementForSec());
		_rigid.AddForce(other.transform.up * PushForce);
		_rigid.AddTorque(Torque);
		Torque += TorqueAdd;
	}

	public IEnumerator BlockMovementForSec()
	{
		WasHit = true;
		yield return new WaitForSeconds(PenaltyTime);
		WasHit = false;
	}
}
