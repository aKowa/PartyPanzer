using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public float explosionScale = 2F;
	public GameObject boom;

	private LifeController lc;
	private Animator anim;

	void Start()
	{
		lc = this.transform.parent.GetComponent<LifeController>();
		anim = this.GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Missile")
		{
			MissileController mc = other.GetComponent<MissileController>();
			if (mc.playerTag != this.transform.parent.tag)
			{
				StartCoroutine(StartExplosion());
				lc.UpdateLife();
				Player.ResetOtherPlayer(this.transform.parent.tag);
			}
		}
	}

	IEnumerator StartExplosion()
	{
		TriggerBoom();
		anim.Play("Explosion2");
		this.GetComponent<CircleCollider2D>().enabled = false;
		this.transform.localScale = Vector3.one * explosionScale;
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}

	private void TriggerBoom()
	{
		GameObject clone = Instantiate(this.boom, this.transform.position, Quaternion.identity) as GameObject;

		if (lc.tag == "Palyer2")
		{
			clone.transform.Rotate(Vector3.back, 180);
		}
	}
}
