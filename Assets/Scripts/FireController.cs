using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    public KeyCode fire = KeyCode.W;
    public float fireRate = 1F;
    public GameObject missile;
    private Transform launcher;
    private bool canFire = true;
	private Animator anim;

    void Awake()
    {
		launcher = transform.FindChild("launch_point");

        if (launcher == null)
        {
            Debug.LogError("Could not find launcher");
        }

		anim = GetComponent<Animator>();
		if (anim == null)
		{
			Debug.LogError("Could not get animator. Not assigned on: " + this.gameObject.name + "?");
		}
    }

    void Update()
    {
        if (Input.GetKeyDown(fire))
        {
            if (canFire)
            {
                StartCoroutine( FireOffset() );
                GameObject clone = Instantiate(missile, launcher.position, launcher.rotation) as GameObject;
                MissileController ms = clone.GetComponent<MissileController>();
                ms.playerTag = this.tag;
				anim.Play("TankFire",1);
            }
        }
    }

    IEnumerator FireOffset()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
