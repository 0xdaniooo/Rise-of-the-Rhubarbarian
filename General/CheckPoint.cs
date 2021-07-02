using UnityEngine;

/*
Used to set up individual checkpoints
Written by Daniel Kasprzyk
*/

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager checkPointManager;

    private void Awake()
    {
        checkPointManager = GetComponentInParent<CheckPointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkPointManager.SetPosition(transform);
        }
    }
}
