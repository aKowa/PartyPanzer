using UnityEngine;
using System.Collections;

public class BoomController : MonoBehaviour {

	public float speed = 1F;
	public float targetSize = 2F;

	void Start ()
	{
		StartCoroutine(Scale());
	}

	IEnumerator Scale()
	{
		for (float i=0; i < 1F; i += speed * Time.deltaTime)
		{
			transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * targetSize, i);
			yield return null;
		}

		Destroy(this.gameObject);
	}
}
