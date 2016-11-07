using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class HitController : MonoBehaviour
{
	public float penaltyTime = 1F;
	public float pushForce = 1F;
	public float torque = 50f;
	public float torqueAdd = 10f;
	[HideInInspector]
	public bool wasHit;
	private Rigidbody2D rigid;

	public void Awake ()
	{
		rigid = this.GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D ( Collider2D other )
	{
		if (other.tag != "Missile" || wasHit) return;
		StartCoroutine(BlockMovementForSec());
		rigid.AddForce(other.transform.up * pushForce);
		rigid.AddTorque(torque);
		torque += torqueAdd;
	}

	public IEnumerator BlockMovementForSec()
	{
		wasHit = true;
		yield return new WaitForSeconds(penaltyTime);
		wasHit = false;
	}
}
