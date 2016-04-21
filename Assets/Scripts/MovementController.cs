using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public float moveSpeed = 1F;
    public float rotateSpeed = 60F;
    private Transform leftRotator;
    private Transform rightRotator;
	private Animator anim;

    void Awake()
    {
		leftRotator = transform.FindChild("left_tread");
		rightRotator = transform.FindChild("right_tread");
        if ( leftRotator == null || rightRotator == null )
        {
            Debug.LogError("Could not find child object");
		}

		anim = GetComponent<Animator>();
		if (anim == null)
		{
			Debug.LogError("Could not get animator. Not assigned on: " + this.gameObject.name + "?");
		}
    }

    void Update()
    {
        if (Input.GetKey(left) && Input.GetKey(right))
        {
			Vector3 targetPosition = transform.position + transform.up * moveSpeed * Time.deltaTime;
			targetPosition.x = Mathf.Clamp(targetPosition.x, -6f, 6f);
			targetPosition.y = Mathf.Clamp(targetPosition.y, -4.7f, 4.7f);
			transform.position = targetPosition;
			anim.SetBool("LeftTread", true);
			anim.SetBool("RightTread", true);
		} 
		else if (anim.GetBool("LeftTread") && anim.GetBool("RightTread"))
		{
			anim.SetBool("LeftTread", false);
			anim.SetBool("RightTread", false);
		}

        else if (Input.GetKey(left))
        {
			transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
			anim.SetBool("LeftTread", true);
        }
		else if (anim.GetBool("LeftTread"))
		{
			anim.SetBool("LeftTread", false);
		}

        else if (Input.GetKey(right))
        {
			transform.Rotate(Vector3.back, -1 * rotateSpeed * Time.deltaTime);
			anim.SetBool("RightTread", true);
        }
		else if (anim.GetBool("RightTread"))
		{
			anim.SetBool("RightTread", false);
		}
    }
}
