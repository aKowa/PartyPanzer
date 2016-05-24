using UnityEngine;
using System.Collections;

[System.Serializable]
public class Buttons
{
	public KeyCode[] Player1Left = { KeyCode.A };
	public KeyCode[] Player1Right = { KeyCode.C, KeyCode.D };
	public KeyCode[] Player1Fire = { KeyCode.DownArrow, KeyCode.W };

	public KeyCode[] Player2Left = { KeyCode.I, KeyCode.LeftArrow };
	public KeyCode[] Player2Right = { KeyCode.RightArrow, KeyCode.Hash, KeyCode.Slash };
	public KeyCode[] Player2Fire = { KeyCode.K,  KeyCode.UpArrow };
}
