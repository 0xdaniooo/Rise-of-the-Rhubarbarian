using UnityEngine;

/*
Listens for input to send to symbol match game
Written by Daniel Kasprzyk
*/

public class SymbolScrollButton : InteractableObject
{
    private SymbolMatchGame symbolMatchGame;

    public enum Direction
    {
        Up, Down
    }

    public Direction direction;

    private void Awake()
    {
        symbolMatchGame = GetComponentInParent<SymbolMatchGame>();
    }

    public override void Interact()
    {
        symbolMatchGame.ScrollInteact(this);
    }
}
