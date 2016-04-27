using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour 
{
    public float speed = 3F;
    public string playerTag = "Player";
	public float explosionScale = 2F;
	private Animator anim;
	private bool hasHit = false;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update () 
	{
		if (!hasHit)
		{
			transform.position += transform.up * speed * Time.deltaTime;
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != playerTag && other.tag != "Border")
		{
			StartCoroutine(StartExplosion());
		}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }

	IEnumerator StartExplosion()
	{
		hasHit = true;
		anim.Play("Explosion1");
		this.GetComponent<BoxCollider2D>().enabled = false;
		this.transform.localScale = Vector3.one * explosionScale;
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}
}
