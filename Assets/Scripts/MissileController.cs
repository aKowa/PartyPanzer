using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour 
{
    public float Speed = 3F;
    public string PlayerTag = "Player";
	public float ExplosionScale = 2F;
	private Animator _anim;
	private bool _hasHit = false;

	private void Start()
	{
		_anim = GetComponent<Animator>();
	}

	private void Update () 
	{
		if (!_hasHit)
		{
			transform.position += transform.up * Speed * Time.deltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != PlayerTag && other.tag != "Border")
		{
			StartCoroutine(StartExplosion());
		}
    }

	private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }

	private IEnumerator StartExplosion()
	{
		_hasHit = true;
		_anim.Play("Explosion1");
		this.GetComponent<BoxCollider2D>().enabled = false;
		this.transform.localScale = Vector3.one * ExplosionScale;
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}
}
