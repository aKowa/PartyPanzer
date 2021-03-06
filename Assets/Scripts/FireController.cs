﻿using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{	
	[Tooltip("The time in seconds needed to reload.")]
    public float fireRate = 1F;
	[Tooltip ( "The missile game object to instanciate, when fired." )]
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

		if (anim == null) return;
		anim.SetFloat ( "SpeedMultiplier", 1f / fireRate );
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
		Fire();
    }

	private IEnumerator FireOffset()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

	// Instantiates the missile and playes animation
	private void Fire()
	{
		var clone = Instantiate ( missile, launcher.position, launcher.rotation ) as GameObject;
		if (clone != null)
		{
			var ms = clone.GetComponent<MissileController> ();
			ms.PlayerTag = this.tag;
		}
		anim.Play ( "TankFire", 2 );
	}
}
