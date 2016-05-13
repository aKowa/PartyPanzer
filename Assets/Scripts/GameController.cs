using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Buttons buttons;
	public GameObject startScreen;
	public GameObject winScreen;
	public float timeToDisplay = 1f;
	public float timeToReset = 2f;
	public GameObject splashScreen;
	public ChangeImage imagePl1;
	public ChangeImage imagePl2;
	private bool isResetting = false;

	void Awake()
	{
		//Screen.fullScreen = true;
	}

	void Start ()
	{
		winScreen.SetActive(false);
		DisplayStartScreen();
		isResetting = false;
	}

	void Update()
	{
		bool pl1Ready = Input.GetKey(buttons.player1Fire) || Input.GetKey(buttons.player1Left) || Input.GetKey(buttons.player1Right);
		bool pl2Ready = Input.GetKey(buttons.player2Fire) ||Input.GetKey(buttons.player2Left) || Utility.GetKeyPress(buttons.player2Right);

		if (pl1Ready)
			imagePl1.SwitchToReady(true);
		else
			imagePl1.SwitchToReady(false);

		if (pl2Ready)
			imagePl2.SwitchToReady(true);
		else
			imagePl2.SwitchToReady(false);

		if ( pl1Ready && pl2Ready)
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
		Destroy(this.splashScreen);
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
		StartCoroutine(TimerToDisplayStart());
	}

	IEnumerator TimerToDisplayStart()
	{
		isResetting = true;

		for (float i = 0; i < timeToReset; i += 1f / 60f)
		{
			yield return null;
		}
		DisplayStartScreen();
		StartCoroutine(TimerToReset());
	}

	IEnumerator TimerToReset()
	{
		for (float i = 0; i < timeToReset; i += 1f / 60f)
		{
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
