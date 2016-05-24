using UnityEngine;

public class InputController : MonoBehaviour
{
	public Buttons Buttons;
	public static bool Player1Left = false;
	public static bool Player1Right = false;
	public static bool Player1Fire = false;
	public static bool Player2Left = false;
	public static bool Player2Right = false;
	public static bool Player2Fire = false;

	public void Update ()
	{
		Player1Left = SetButton( Buttons.Player1Left );
		Player1Right = SetButton ( Buttons.Player1Right );
		Player1Fire = SetButton ( Buttons.Player1Fire );

		Player2Left = SetButton ( Buttons.Player2Left );
		Player2Right = SetButton ( Buttons.Player2Right );
		Player2Fire = SetButton ( Buttons.Player2Fire );
		Debug.Log(Player1Left);
	}

	private bool SetButton(KeyCode[] keyCodes)
	{
		foreach (var c in keyCodes)
		{
			if (Input.GetKey(c))
				return true;
		}
		return false;
	}
}
