using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 1F;
    public float rotateSpeed = 60F;
    private Transform leftRotator;
    private Transform rightRotator;
	private Animator anim;

	private void Awake()
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

	private void Update()
	{
		var left = false;
		var right = false;

		switch (this.tag)
		{
			case "Player1":
				left = InputController.Player1Left;
				right = InputController.Player1Right;
				break;
			case "Player2":
				left = InputController.Player2Left;
				right = InputController.Player2Right;
				break;
		}

        if (left && right )
        {
			var targetPosition = transform.position + transform.up * moveSpeed * Time.deltaTime;
			transform.position = targetPosition.ClampToBorder();
			anim.SetBool("LeftTread", true);
			anim.SetBool("RightTread", true);
		}
		else if (anim.GetBool("LeftTread") && anim.GetBool("RightTread"))
		{
			anim.SetBool("LeftTread", false);
			anim.SetBool("RightTread", false);
		}

        else if (left)
        {
			transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
			anim.SetBool("LeftTread", true);
        }
		else if (anim.GetBool("LeftTread"))
		{
			anim.SetBool("LeftTread", false);
		}

        else if (right)
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
