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

    void Awake()
    {
		leftRotator = transform.FindChild("left_tread");
		rightRotator = transform.FindChild("right_tread");

        if ( leftRotator == null || rightRotator == null )
        {
            Debug.LogError("Could not find child object");
        }
    }

    void Update()
    {
        if (Input.GetKey(left) && Input.GetKey(right))
        {
			Vector3 targetPosition = transform.position + transform.up * moveSpeed * Time.deltaTime;
			targetPosition.x = Mathf.Clamp(targetPosition.x, -6.32f, 3.32f);
			targetPosition.y = Mathf.Clamp(targetPosition.y, -4.7f, 4.7f);
			transform.position = targetPosition;
        }

        if (Input.GetKey(left))
        {
			transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(right))
        {
			transform.Rotate(Vector3.back, -1 * rotateSpeed * Time.deltaTime);
        }
    }
}
