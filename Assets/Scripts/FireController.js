#pragma strict

public var fire = KeyCode.W;
public var fireRate = 1F;
public var launcher: Transform;
public var missile: GameObject;
private var canFire = true;

function Update()
{
    if (Input.GetKeyDown(fire))
    {
        if (canFire)
        {
            FireOffset();
            var clone = Instantiate(missile, launcher.position, launcher.rotation) as GameObject;
            clone.GetComponent(MissileController).playerTag = this.tag;
        }
    }
}

function FireOffset()
{
    canFire = false;
    yield WaitForSeconds(fireRate);
    canFire = true;
}