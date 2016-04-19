using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    public KeyCode fire = KeyCode.W;
    public float fireRate = 1F;
    public GameObject missile;

    private Transform launcher;
    private bool canFire = true;

    protected void Awake()
    {
        launcher = transform.FindChild("launcher");

        if (launcher == null)
        {
            Debug.LogError("Could not find launcher");
        }
    }


    protected void Update()
    {
        if (Input.GetKeyDown(fire))
        {
            if (canFire)
            {
                StartCoroutine( FireOffset() );
                GameObject clone = Instantiate(missile, launcher.position, launcher.rotation) as GameObject;
                MissileController ms = clone.GetComponent<MissileController>();
                ms.playerTag = this.tag;
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
