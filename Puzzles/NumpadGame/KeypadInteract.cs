using UnityEngine;

/*
Interaction button listener for the number pad game
Written by Daniel Kasprzyk
*/

public class KeypadInteract : InteractableObject
{
    public int number;
    private NumpadGame numpadGame;

    private void Awake()
    {
        numpadGame = GetComponentInParent<NumpadGame>();
    }

    public override void Interact()
    {
        numpadGame.AddDigit(number);
    }
}
