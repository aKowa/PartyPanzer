using UnityEngine;
using System.Collections;

public class DancefloorController : MonoBehaviour
{
	public float timeTick = 1;
	public Vector2 addOffset = new Vector2(0.5f, 0.25f);
	private MeshRenderer rend;

	private void Start()
	{
		this.rend = GetComponent<MeshRenderer>();
		StartCoroutine(Wait());
	}

	private IEnumerator Wait()
	{
		for (float i = 0; i < timeTick; i += timeTick / 60)
		{
			yield return null;
		}
		SetOffset();
	}

	private void SetOffset()
	{
		var offset = rend.material.GetTextureOffset("_MainTex");
		offset += addOffset;
		offset.x = offset.x % 1;
		offset.y = offset.y % 1;
		rend.material.SetTextureOffset("_MainTex", offset);
		StartCoroutine(Wait());
	}
}
