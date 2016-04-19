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
        leftRotator = transform.FindChild("left_rotator");
        rightRotator = transform.FindChild("right_rotator");

        if ( leftRotator == null || rightRotator == null )
        {
            Debug.LogError("Could not find child object");
        }
    }

    void Update()
    {
        if (Input.GetKey(left) && Input.GetKey(right))
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(left))
        {
//          transform.RotateAround(rightRotator.position, Vector3.back, rotateSpeed * Time.deltaTime);
			transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(right))
        {
//			transform.RotateAround(leftRotator.position, Vector3.back, -1 * rotateSpeed * Time.deltaTime);
			transform.Rotate(Vector3.back, -1 * rotateSpeed * Time.deltaTime);
        }
    }
}
