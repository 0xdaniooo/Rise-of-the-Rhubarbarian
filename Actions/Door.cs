using System.Collections;
using UnityEngine;

/*
Opens a door
Written by Daniel Kasprzyk
*/

public class Door : GameAction
{
    public float doorOpenDistance = 4f;
    public float openSpeed = 5f;
    public float openTime = 2f;
    public GameObject door;
    private Vector3 updatedPosition;

    private void Start()
    {
        updatedPosition = door.transform.position;
        updatedPosition.y += doorOpenDistance;
    }

    public override void Action()
    {
        door.transform.position += new Vector3(0, doorOpenDistance, 0);
    }

    /*public float doorOpenDistance = 4f;
    private Transform door;
    private Vector3 updatedPosition;

    public enum OpenDirection
    {
        Up, Down, Left, Right
    }

    public OpenDirection openDir;

    private void Start()
    {
        door = GetComponent<Transform>();

        updatedPosition = door.transform.position;
        //updatedPosition.y += doorOpenDistance;

        switch (openDir)
        {
            case OpenDirection.Up:
                updatedPosition.y += doorOpenDistance;
                break;

            case OpenDirection.Down:
                updatedPosition.y -= doorOpenDistance;
                break;

            case OpenDirection.Left:
                updatedPosition.x -= doorOpenDistance;
                break;

            case OpenDirection.Right:
                updatedPosition.x += doorOpenDistance;
                break;
        }
    }

    public override void Action()
    {
        door.transform.position += updatedPosition;
    }*/
}

