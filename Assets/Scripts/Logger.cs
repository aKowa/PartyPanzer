using UnityEngine;
using System.Collections;
using System.IO;

public class Logger : MonoBehaviour
{
	public static int totalSessions = 0;
	public static int consequitiveSessions = 0;
	public static float totalPlaytime = 0;

	private static string s_totalSessions = "Total Sessions";
	private static string s_consequitiveSessions = "Consequitive Sessions";
	private static string s_totalPlaytime = "Total Playtime";

	void Awake()
	{
		GetLog();
		totalSessions++;
		SetLog();
		SetText();
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
		SetText();
	}

	private void SetText()
	{
		string output = s_totalSessions + ": " + totalSessions.ToString() + "   " +
						s_consequitiveSessions + ": " + consequitiveSessions + "   " +
						s_totalPlaytime + ":  " + totalPlaytime;
		System.IO.File.WriteAllText(Application.persistentDataPath + "/PartyPanzerLog.txt", output);
	}
}
