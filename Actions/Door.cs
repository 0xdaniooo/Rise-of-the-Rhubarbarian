using System.Collections;
using UnityEngine;

/*
Opens a door
Written by Daniel Kasprzyk
*/

public class Door : GameAction
{
    public float openDistance = 4f;
    public float timeModifier = 1f;
    public GameObject door;
    public bool doorOpen = false;
    private Vector3 destination;

    private void Awake()
    {
        destination = door.transform.position;
        destination.y += openDistance;
    }

    public override void Action()
    {
        doorOpen = true;
    }

    private void Update()
    {
        if (doorOpen && transform.position.y <= destination.y)
        {
            door.transform.position += new Vector3(0, openDistance, 0) * timeModifier;
        }
    }
}

