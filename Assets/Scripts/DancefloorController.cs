using UnityEngine;
using System.Collections;

public class DancefloorController : MonoBehaviour
{
	public float timeTick = 1;
	public Vector2 addOffset = new Vector2(0.5f, 0.25f);
	private MeshRenderer rend;
	
	void Start()
	{
		this.rend = GetComponent<MeshRenderer>();
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(timeTick);
		SetOffset();
	}

	private void SetOffset()
	{
		Vector2 offset = rend.material.GetTextureOffset("_MainTex");
		offset += addOffset;
		offset.x = offset.x % 1;
		offset.y = offset.y % 1;
		Debug.Log(offset);
		rend.material.SetTextureOffset("_MainTex", offset);
		StartCoroutine(Wait());
	}
}
