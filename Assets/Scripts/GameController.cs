using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Buttons buttons;
	public GameObject startScreen;
	public GameObject winScreen;
	public float timeToStartScreen = 2f;
	public float timeToReset = 2f;
	public Text resetTimer1;
	public Text resetTimer2;
	private bool isResetting = false;

	void Start () 
	{
		DisplayStartScreen();
		winScreen.SetActive(false);
		isResetting = false;
		resetTimer1.gameObject.SetActive(false);
		resetTimer2.gameObject.SetActive(false);
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
				StopAllCoroutines();
				Application.LoadLevel(Random.Range(0, Application.levelCount));
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

		for ( float i=timeToStartScreen; i >= 0; i -= 1/60f)
		{
			yield return null;
		}

		DisplayStartScreen();

		resetTimer1.gameObject.SetActive(true);
		resetTimer2.gameObject.SetActive(true);
		for ( float i=timeToReset; i >= 0; i -= 1/60f)
		{
			string s = ((int)i).ToString();
			resetTimer1.text = s;
			resetTimer2.text = s;
			yield return null;
		}
		resetTimer1.gameObject.SetActive(false);
		resetTimer2.gameObject.SetActive(false);

		isResetting = false;
		print("reset game"); 
		Application.LoadLevel(Random.Range(0, Application.levelCount));
	}
}
