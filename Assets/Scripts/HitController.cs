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

	private MovementController _movementController;
	private bool canApply = true;
	private float initMoveSpeed;
	private float initRotateSpeed;

	private void Awake ()
	{
		_movementController = this.GetComponent<MovementController>();
		initMoveSpeed = _movementController.moveSpeed;
		initRotateSpeed = _movementController.rotateSpeed;
	}

	private void OnTriggerEnter2D( Collider2D other )
	{
		if (other.tag != "Missile" || !canApply) return;
		StartCoroutine(Rotate());
		StartCoroutine(Push(other.transform.up));
		_movementController.moveSpeed *= penaltySpeed;
		_movementController.rotateSpeed *= penaltySpeed;
		penaltyAngle += penaltyAngleAdd;
		penaltyTime += penaltyTimeAdd;
	}

	private IEnumerator Rotate()
	{
		canApply = false;

		var rotateDirection = Random.Range(-1, 1);

		if (rotateDirection == 0)
		{
			rotateDirection = 1;
		}

		var initRotation = transform.rotation.eulerAngles;
		var targetRotationZ = Vector3.forward * (initRotation.z + (float)rotateDirection * Random.Range(penaltyAngle - 5f, penaltyAngle + 5f));

		for (float i = 0; i < 1; i += penaltyTime * Time.deltaTime)
		{
			var targetRotation = Vector3.Lerp(initRotation, targetRotationZ,i);
			transform.rotation = Quaternion.Euler(targetRotation);
			yield return null;
		}

		_movementController.moveSpeed = initMoveSpeed;
		_movementController.rotateSpeed = initRotateSpeed;
		canApply = true;
	}

	private IEnumerator Push(Vector3 direction)
	{
		var origin = this.transform.position;
		var target = origin + direction * pushDistance;
		for (float i=0; i < 1F; i += pushTime * Time.deltaTime)
		{
			var v = Vector3.Lerp(origin, target, i);
			transform.position = v.ClampToBorder();
			yield return null;
		}
	}
}
