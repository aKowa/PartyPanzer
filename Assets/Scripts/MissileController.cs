using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

    public float speed = 3F;
    public string playerTag = "Player";

	void Update () 
	{
        transform.position += transform.up * speed * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag != playerTag && other.tag != "Border")
		{
			Destroy(this.gameObject);
		}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
