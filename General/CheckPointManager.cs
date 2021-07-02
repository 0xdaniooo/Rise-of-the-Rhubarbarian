using System.Collections;
using UnityEngine;

/*
Manages all the checkpoints in the level
Written by Daniel Kasprzyk
*/

public class CheckPointManager : MonoBehaviour
{
    private GameObject player;
    public Vector3 checkPointPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        checkPointPos = player.transform.position;
    }

    public void SetPosition(Transform pos)
    {
        checkPointPos = pos.transform.position;
    }

    public void RepositionPlayer()
    {
        player.transform.position = checkPointPos;
    }
}
