#pragma strict

public var left = KeyCode.A;
public var right = KeyCode.D;

public var moveSpeed = 1F;
public var rotateSpeed = 1F;

function Update () 
{
	if (Input.GetKey(left) && Input.GetKey(right))
    {
    	var targetPos = transform.position + transform.up * moveSpeed * Time.deltaTime;
    	targetPos.x = Mathf.Clamp(targetPos.x,-6.32f, 6.32f);
    	targetPos.y = Mathf.Clamp(targetPos.y,-4.7f, 4.7f);
    	transform.position = targetPos;
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