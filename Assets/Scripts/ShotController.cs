using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	private LifeController lc;

	void Start()
	{
		lc = this.transform.parent.GetComponent<LifeController>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Missile")
		{
			MissileController mc = other.GetComponent<MissileController>();
			if (mc.playerTag != this.transform.parent.tag)
			{
				Destroy(this.gameObject);
				lc.UpdateLife(); 
			}
		}
	}
}
