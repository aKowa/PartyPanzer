using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

	public int hitpoints = 0;

	void OnTriggerEnter2D( Collider2D other )
	{
		if (other.tag == "Missile")
		{
			--hitpoints;

			if ( hitpoints < 0 )
			{
				Destroy(this.gameObject);
			}
		}
	}
}
