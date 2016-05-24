using UnityEngine;

public class InputController : MonoBehaviour
{
	public Buttons Buttons;
	private static Buttons _buttons;

	public void Awake ()
	{
		_buttons = Buttons;
	}

	public static bool Player1Left
	{
		get
		{
			return Utility.GetKeyPress ( _buttons.Player1Left );
		}
	}

	public static bool Player1Right
	{
		get
		{
			return Utility.GetKeyPress ( _buttons.Player1Right );
		}
	}

	public static bool Player1Fire
	{
		get
		{
			return Utility.GetKeyPress ( _buttons.Player1Fire );
		}
	}

	public static bool Player2Left
	{
		get
		{
			return Utility.GetKeyPress ( _buttons.Player2Left );
		}
	}

	public static bool Player2Right
	{
		get
		{
			return Utility.GetKeyPress ( _buttons.Player2Right );
		}
	}

	public static bool Player2Fire
	{
		get
		{
			return Utility.GetKeyPress ( _buttons.Player2Fire );
		}
	}
}
