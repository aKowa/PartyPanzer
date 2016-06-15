using UnityEngine;
using System.Collections;

public class TitleRotation : MonoBehaviour {

	[Tooltip("The rotation speed. MUST be positive!")]
	public float Speed = 1f;

	void Start ()
	{
		StartCoroutine ( Rotation () );
	}

	private IEnumerator Rotation ()
	{
		for (float i = 0; i < 1; i += Speed / 60)
		{
			var targetRotation = transform.rotation.eulerAngles;
			targetRotation.z = Mathf.Lerp ( 0, 360, i );
			transform.rotation = Quaternion.Euler ( targetRotation );
			yield return null;
		}
		StartCoroutine ( Rotation () );
	}
}
