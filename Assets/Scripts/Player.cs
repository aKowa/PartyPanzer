using UnityEngine;
using System.Collections;

public static class Player
{
	public static PlayerController one;
	public static PlayerController two;

	public static float xBorder = 6F;
	public static float yBorder = 4.7F;

	public static PlayerController GetOtherPlayer(string str)
	{
		if (str == "Player1")
		{
			return two;
		}
		else if (str == "Player2")
		{
			return one;
		}

		return null;
	}

	public static void ResetOtherPlayer(string str)
	{
		GetOtherPlayer(str).Reset();
	}
}
