using UnityEngine;

/*
Hosts the hikimi game and all its functionality
Written by Daniel Kasprzyk
*/

public class HikimiGame : MonoBehaviour
{
    public HikimiPuzzlePiece[] puzzlePieces;
    public GameAction action;
    [HideInInspector] public Camera cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void OpenGame()
    {
        foreach (HikimiPuzzlePiece piece in puzzlePieces)
        {
            piece.enabled = true;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseGame()
    {
        foreach (HikimiPuzzlePiece piece in puzzlePieces)
        {
            piece.enabled = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    //Controls the state of pieces when the player is interacting with them
    public void PieceControl(HikimiPuzzlePiece pieceToStay, bool toggle)
    {
        foreach (HikimiPuzzlePiece piece in puzzlePieces)
        {
            if (piece != pieceToStay)
            {
                piece.enabled = toggle;
            }
        }
    }

    public void CheckPieces()
    {
        int amount = puzzlePieces.Length;
        int correct = 0;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            HikimiPuzzlePiece piece = puzzlePieces[i].transform.GetComponent<HikimiPuzzlePiece>();

            if (piece.completed)
            {
                correct ++;
            }
        }

        print("Correct: " + correct + " / " + amount);

        if (amount == correct)
        {
            action.Action();
            print("Puzzle solved");
        }
    }
}
