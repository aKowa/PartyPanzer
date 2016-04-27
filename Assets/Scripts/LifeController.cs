using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{
	public GameController gc;
	public int lifepoints = 1;
	
	public void Start()
	{
		lifepoints = this.transform.childCount;
	}

	public void UpdateLife()
	{
		--lifepoints;
		print(this.transform.tag + " has " + lifepoints + " Life left");

		if ( lifepoints <= 0 )
		{
			gc.DisplayWinScreen(this.transform.tag);
		}
	}
}
