using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

[RequireComponent ( typeof ( Text ) )]
public class WinCounterController : MonoBehaviour
{
	private Text text;

	private void Awake ()
	{
		text = this.GetComponent<Text> ();
		text.text = "Wins: " + PlayerPrefs.GetInt ( this.tag + "WinCount", 0 );
	}

	public void IncreaseWins ()
	{
		var wins = PlayerPrefs.GetInt ( this.tag + "WinCount", 0 ) + 1;
		PlayerPrefs.SetInt ( this.tag + "WinCount", wins );
		text.text = "Wins: " + wins;
	}

	public void OnApplicationQuit ()
	{
		PlayerPrefs.DeleteKey ( this.tag + "WinCount" );
	}
}
