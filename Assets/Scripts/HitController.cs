using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour {

	public float speedPenalty = 0.5F;
	public float penaltyTime = 1F;

	private MovementController mc;
	private bool canApply = true;

	void Awake ()
	{
		mc = this.GetComponent<MovementController>();
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.tag == "Missile" && canApply ) 
		{
			StartCoroutine(OffsetTime());
			mc.moveSpeed *= speedPenalty;
			mc.rotateSpeed *= speedPenalty;
		}
	}

	IEnumerator OffsetTime()
	{
		canApply = false;
		yield return new WaitForSeconds(penaltyTime);
		mc.moveSpeed /= speedPenalty;
		mc.rotateSpeed /= speedPenalty;
		canApply = true;
	}
}
