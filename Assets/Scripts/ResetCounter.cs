using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCounter : MonoBehaviour
{
	public void Start ()
	{
		PlayerPrefs.SetInt( "Player1WinCount", 0 );
		PlayerPrefs.SetInt( "Player2WinCount", 0 );
		PlayerPrefs.Save();
		SceneManager.LoadScene( Random.Range(1, SceneManager.sceneCount));
	}
}
