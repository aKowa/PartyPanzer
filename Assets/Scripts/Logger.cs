using UnityEngine;
using System.Collections;
using System.IO;

public class Logger : MonoBehaviour
{
	public static int totalSessions = 0;
	public static int consequitiveSessions = 0;
	public static float totalPlaytime = 0;
	public static string output;
	public bool reset = false;

	private static string s_totalSessions = "Total Sessions";
	private static string s_consequitiveSessions = "Consequitive Sessions";
	private static string s_totalPlaytime = "Total Playtime";

	void Awake()
	{
		GetLog();
		totalSessions++;
		SetLog();
	}

	public static void SetLog()
	{
		PlayerPrefs.SetInt(s_totalSessions, totalSessions);
		PlayerPrefs.SetInt(s_consequitiveSessions, consequitiveSessions);
		PlayerPrefs.SetFloat(s_totalPlaytime, totalPlaytime);
		PlayerPrefs.Save();
	}

	private void GetLog()
	{
		totalSessions = PlayerPrefs.GetInt(s_totalSessions);
		consequitiveSessions = PlayerPrefs.GetInt(s_consequitiveSessions);
		totalPlaytime = PlayerPrefs.GetFloat(s_totalPlaytime);
	}

	public void OnApplicationQuit()
	{
		SetLog();
	}

	private void ResetPlayerPrefs()
	{
		totalSessions = 0;
		consequitiveSessions = 0;
		totalPlaytime = 0;
		SetLog();
	}

	public void Update()
	{
		if (reset)
		{
			reset = false;
			ResetPlayerPrefs();
		}
	}
}
