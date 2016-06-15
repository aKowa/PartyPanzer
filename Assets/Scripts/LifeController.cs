using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{
	public GameController gc;
	public WinCounterController WinCunter;
	public int lifepoints = 1;
	
	public void Start()
	{
		lifepoints = this.transform.childCount;
	}

	public void UpdateLife()
	{
		--lifepoints;
		if ( lifepoints <= 0 )
		{
			gc.DisplayWinScreen(this.tag);
			WinCunter.IncreaseWins();
		}
	}
}
