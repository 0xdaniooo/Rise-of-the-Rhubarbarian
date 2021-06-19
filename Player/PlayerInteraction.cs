using UnityEngine;

/*
Manages interactions for the player
Written by Daniel Kasprzyk
*/

public class PlayerInteraction : MonoBehaviour
{
    //Interact values
    public Camera cam;
    public float interactionDistance;
    public LayerMask ignoreLayer;
    private KeyCode interactKey = KeyCode.F;

    private void Update()
    {
        //Ignore player with raycast
        LayerMask rayLayer = ~ignoreLayer;

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance, rayLayer))
        {
            //Check for regular interaction
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                //Prepare interaction input
                HandleInteraction(interactable);
                successfulHit = true;                
            }
        }
    }

    private void HandleInteraction(InteractableObject interactable) 
    {
        switch (interactable.interactionType) 
        {
            case InteractableObject.InteractionType.Click:

                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact();
                }

                break;

            case InteractableObject.InteractionType.Hold:
                if (Input.GetKey(interactKey))
                {
                    interactable.IncreaseHoldTime();

                    if (interactable.GetCurrentHoldTime() > interactable.interactHoldTime)
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }

                else interactable.ResetHoldTime();
                break;

            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}