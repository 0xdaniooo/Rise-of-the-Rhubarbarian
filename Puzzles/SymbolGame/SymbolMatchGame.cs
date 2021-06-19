using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Hosts the symbol match game and all its functionality
Written by Daniel Kasprzyk
*/

public class SymbolMatchGame : MonoBehaviour
{
    public GameObject[] symbols;
    public GameObject symbolBoard;
    public int correctSymbol;
    public bool solved = false;
    public float movementForce;
    public GameAction action;

    private Rigidbody symbolRb;
    private Transform symbolCast;

    private void Awake()
    {
        symbolRb = GetComponentInChildren<Rigidbody>();

        if (correctSymbol < symbols.Length)
        {
            symbolCast = symbols[correctSymbol].transform;
        }
    }

    public void ScrollInteact(SymbolScrollButton scrollDir)
    {
        switch (scrollDir.direction)
        {
            case SymbolScrollButton.Direction.Up:
                ScrollMovement(Vector3.up);
                break;

            case SymbolScrollButton.Direction.Down:
                ScrollMovement(Vector3.down);
                break;
        }
    }

    private void ScrollMovement(Vector3 direction)
    {
        symbolRb.AddForce(direction * movementForce);

        if (KeyCast() && !solved)
        {
            solved = true;
            action.Action();
            print("Puzzle solved");
        }
    }

    private bool KeyCast()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(symbolCast.position, Vector3.left, out hit, 3f))
        {
            if (hit.transform.tag == ("CorrectSymbol"))
            {
                return true;
            }
        }

        return false;
    }
}
