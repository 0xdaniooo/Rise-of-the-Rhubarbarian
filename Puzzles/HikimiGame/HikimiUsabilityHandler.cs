using UnityEngine;

/*
Grants the player access to the hikimi board
Written by Daniel Kasprzyk
*/

public class HikimiUsabilityHandler : MonoBehaviour
{
    private HikimiGame hikimi;

    private void Awake()
    {
        hikimi = GetComponentInParent<HikimiGame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hikimi.OpenGame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hikimi.CloseGame();
        }
    }
}
