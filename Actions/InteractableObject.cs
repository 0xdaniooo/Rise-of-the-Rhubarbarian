using UnityEngine;

/*
Inherited by objects to give them interaction functionality
Written by Daniel Kasprzyk
*/

public abstract class InteractableObject : MonoBehaviour
{
    public enum InteractionType
    {
        Click, Hold
    }

    public float interactHoldTime;

    private float holdTime;

    public InteractionType interactionType;

    public abstract void Interact();

    public void IncreaseHoldTime() => holdTime += Time.deltaTime;
    public void ResetHoldTime() => holdTime = 0f;

    public float GetCurrentHoldTime() => holdTime;
}
