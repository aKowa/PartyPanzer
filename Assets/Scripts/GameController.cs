using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Buttons buttons;
	public GameObject startScreen;
	public GameObject winScreen;
	public float timeToReload = 2f;
	private bool isResetting = false;

	void Awake()
	{
		Screen.fullScreen = true;
	}

	void Start ()
	{
		winScreen.SetActive(false);
		DisplayStartScreen();
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
				LoadRandomScene();
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

	public void DisplayStartScreen()
	{
		Time.timeScale = 0;
		startScreen.SetActive(true);
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

	IEnumerator ResetTime()
	{
		isResetting = true;

		for (float i = 0; i < timeToReload; i += 1/60)
		{
			print(1/60);
			print("resetting, i: " + i);
			yield return null;
		}

		LoadRandomScene();
	}

	private void LoadRandomScene()
	{
		isResetting = false;
		StopAllCoroutines();
		Logger.consequitiveSessions++;
		Logger.totalPlaytime += Time.time;
		Logger.SetLog();
		SceneManager.LoadScene(Random.Range(0, SceneManager.sceneCountInBuildSettings));
	}
}
