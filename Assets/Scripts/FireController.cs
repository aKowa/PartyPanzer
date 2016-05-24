using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{	
    public float fireRate = 1F;
    public GameObject missile;
    private Transform launcher;
    private bool canFire = true;
	private Animator anim;

	private void Awake()
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

	private void Update()
	{
		var fire = false;
		switch (this.tag)
		{
			case "Player1":
				fire = InputController.Player1Fire;
				break;
			case "Player2":
				fire = InputController.Player2Fire;
				break;
		}

	    if (!fire || !(Time.timeScale > 0)) return;
	    if (!canFire) return;
	    StartCoroutine( FireOffset() );
	    var clone = Instantiate(missile, launcher.position, launcher.rotation) as GameObject;
	    if (clone != null)
	    {
		    var ms = clone.GetComponent<MissileController>();
		    ms.playerTag = this.tag;
	    }
	    anim.Play("TankFire",2);
    }

	private IEnumerator FireOffset()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
