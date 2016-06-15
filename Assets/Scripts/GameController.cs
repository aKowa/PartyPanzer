using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{ 	
	public GameObject startScreen;
	public GameObject winScreen;
	public float timeToReset = 2f;
	public GameObject splashScreen;
	public ChangeImage imagePl1;
	public ChangeImage imagePl2;
	private bool isResetting = false;

	private void Start ()
	{
		winScreen.SetActive(false);
		DisplayStartScreen();
		isResetting = false;
	}

	private void Update()
	{
		var pl1Ready = InputController.Player1Left || InputController.Player1Right || InputController.Player1Fire;
		var pl2Ready = InputController.Player2Left || InputController.Player2Right || InputController.Player2Fire;

		imagePl1.SwitchToReady(pl1Ready);
		imagePl2.SwitchToReady(pl2Ready);

		if ( pl1Ready && pl2Ready)
		{
			if (isResetting)
			{
				LoadRandomScene();
			}
			else
			{
				StartGame();
			}
		}
	}

	private void StartGame()
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
		StartCoroutine(TimerToReset());
	}

	private IEnumerator TimerToReset()
	{
		isResetting = true;
		for (float i = 0; i < timeToReset; i += 1f / 60f)
		{
			yield return null;
		}
		isResetting = false;
		LoadRandomScene();
	}

	private void LoadRandomScene()
	{
		isResetting = false;
		StopAllCoroutines();
		Logger.consequitiveSessions++;
		Logger.totalPlaytime += Time.time;
		Logger.SetLog();
		SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings));
	}
}
