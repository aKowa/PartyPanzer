using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour {

	public float penaltySpeed = 0.5F;
	public float penaltyTime = 1F;
	public float penaltyTimeAdd = 0.5f;
	public float penaltyAngle = 50f;
	public float penaltyAngleAdd = 10f;
	public float pushDistance = 1F;
	public float pushTime = 1F;

	private MovementController mc;
	private bool canApply = true;
	private float initMoveSpeed;
	private float initRotateSpeed;

	void Awake ()
	{
		mc = this.GetComponent<MovementController>();
		initMoveSpeed = mc.moveSpeed;
		initRotateSpeed = mc.rotateSpeed;
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.tag == "Missile" && canApply ) 
		{
			StartCoroutine(Rotate());
			StartCoroutine(Push(other.transform.up));
			mc.moveSpeed *= penaltySpeed;
			mc.rotateSpeed *= penaltySpeed;
			penaltyAngle += penaltyAngleAdd;
			penaltyTime += penaltyTimeAdd;

		}
	}

	IEnumerator Rotate()
	{
		canApply = false;

		int rotateDirection = Random.Range(-1, 1);

		if (rotateDirection == 0)
		{
			rotateDirection = 1;
		}

		Vector3 initRotation = transform.rotation.eulerAngles;
		Vector3 targetRotationZ = Vector3.forward * (initRotation.z + (float)rotateDirection * Random.Range(penaltyAngle - 5f, penaltyAngle + 5f));

		for (float i = 0; i < 1; i += penaltyTime * Time.deltaTime)
		{
			Vector3 targetRotation = Vector3.Lerp(initRotation, targetRotationZ,i);
			transform.rotation = Quaternion.Euler(targetRotation);
			yield return null;
		}

		mc.moveSpeed = initMoveSpeed;
		mc.rotateSpeed = initRotateSpeed;
		canApply = true;
	}

	IEnumerator Push(Vector3 direction)
	{
		Vector3 origin = this.transform.position;
		Vector3 target = origin + direction * pushDistance;
		for (float i=0; i < 1F; i += pushTime * Time.deltaTime)
		{
			Vector3 v = Vector3.Lerp(origin, target, i);
			transform.position = v.ClampToBorder();
			yield return null;
		}
	}
}
