#pragma strict

public var speedPenalty = 0.5F;
public var penaltyTime = 1F;

private var mc: MovementController;
private var canApply = true;

function Awake()
{
	mc = this.GetComponent(MovementController);

	if ( mc == null )
	{
		Debug.LogError("Did not get MovementController");
	}
}

function OnTriggerEnter2D( other: Collider2D )
{
	if ( other.tag == "Missile" && canApply ) 
	{
		OffsetTime();
		mc.moveSpeed *= speedPenalty;
		mc.rotateSpeed *= speedPenalty;
	}
}

function OffsetTime()
{
	canApply = false;
	yield WaitForSeconds(penaltyTime);
	mc.moveSpeed /= speedPenalty;
	mc.rotateSpeed /= speedPenalty;
	canApply = true;
}