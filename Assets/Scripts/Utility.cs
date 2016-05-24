using UnityEngine;

public static class Utility
{
	public static bool GetKeyPress(KeyCode[] keys)
	{
		foreach (KeyCode k in keys)
		{
			if (Input.GetKey(k))
			{
				return true;
			}
		}
		return false;
	}
}
