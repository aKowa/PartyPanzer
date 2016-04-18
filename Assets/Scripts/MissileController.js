#pragma strict

public var speed = 2F;
public var playerTag = "Player";

function Update () 
{
    transform.position += transform.up * speed * Time.deltaTime;
}

function OnTriggerEnter2D(other: Collider2D)
{
    if(other.tag != playerTag && other.tag != "Border")
    {
        Destroy(this.gameObject);
    } 
    else if (other.tag == "Player" || other.tag == "Player2")
    {
    	print("hit");
    }
}

function OnTriggerExit2D(other: Collider2D)
{
    if (other.tag == "Border")
    {
        Destroy(this.gameObject);
    }
}