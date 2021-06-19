using UnityEngine;

/*
Used for setting up buttons
Written by Daniel Kasprzyk
*/

public class InteractButton : MonoBehaviour
{
    /*public string tagName;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == tagName)
        {
            print("Button activated");
        }
    }*/

    public string tagName;
    public GameAction action;

    private bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpened && other.gameObject.tag == tagName)
        {
            isOpened = true;
            action.Action();
        }
    }
}
