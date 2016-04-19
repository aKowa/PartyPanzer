using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Buttons buttons;
	public GameObject startScreen;
	public GameObject winScreen;
//	public float timeToReset = 1f;

	private bool isResetting = false;

	void Start () 
	{
		DisplayStartScreen();
		winScreen.SetActive(false);
		isResetting = false;
	}

	void Update()
	{
		if ((
			Input.GetKey(buttons.player1Fire) ||
			Input.GetKey(buttons.player1Left) ||
			Input.GetKey(buttons.player1Right)
		) && (
			Input.GetKey(buttons.player2Fire) ||
			Input.GetKey(buttons.player2Left) ||
			Input.GetKey(buttons.player2Right)
		))
		{
			if (isResetting)
			{
				Application.LoadLevel(0);
			}
			else if (Time.timeScale  < 1)
			{
				StartGame();
			}
		}
	}

	void StartGame()
	{
		Time.timeScale = 1;
		startScreen.SetActive(false);
		winScreen.SetActive(false);
	}

	public void DisplayWinScreen (string looserTag)
	{
		Time.timeScale = 0;
		winScreen.SetActive(true);

		if (looserTag == "Player2")
		{
			winScreen.transform.rotation = Quaternion.identity;
		} 
		else if ( looserTag == "Player1")
		{
			winScreen.transform.rotation = Quaternion.Euler( Vector3.forward * 180f);
		}

		StartCoroutine( ResetTime() );
	}

	public void DisplayStartScreen ()
	{
		Time.timeScale = 0;
		startScreen.SetActive(true);
	}

	IEnumerator ResetTime()
	{
		isResetting = true;

		yield return new WaitForSeconds(1);

		DisplayStartScreen();
		isResetting = false;

		yield return new WaitForSeconds(1);

		print("reset game"); 
		Application.LoadLevel(0);
	}
}
