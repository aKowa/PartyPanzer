using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public float explosionScale = 2F;

	private LifeController lc;
//	private bool isHit = false;
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
			}
		}
	}

	IEnumerator StartExplosion()
	{
		anim.Play("Explosion2");
		this.GetComponent<CircleCollider2D>().enabled = false;
		this.transform.localScale = Vector3.one * explosionScale;
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}
}
