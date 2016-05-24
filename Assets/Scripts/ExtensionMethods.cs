using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
	public static Vector3 ClampToBorder(this Vector3 vec)
	{
		//vec.x = Mathf.Clamp(vec.x, -Player.xBorder, Player.xBorder);
		//vec.y = Mathf.Clamp(vec.y, -Player.yBorder, Player.yBorder);
		return vec;
	}
}
