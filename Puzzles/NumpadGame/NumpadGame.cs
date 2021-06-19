using UnityEngine;
using TMPro;

/*
Hosts the number game and all its functionality
Written by Daniel Kasprzyk
*/

public class NumpadGame : MonoBehaviour
{
    private int counter;
    public string code;
    private string inputCode;
    public bool solved = false;
    public GameAction action;
    public TextMeshProUGUI text;

    public void AddDigit(int num)
    {
        string numParse = num.ToString();

        inputCode += numParse;
        print("Pressed " + num);

        CheckCode();
    }

    private void CheckCode()
    {
        if (!solved)
        {
            if (inputCode == code)
            {
                solved = true;
                action.Action();
                text.SetText("Correct!");
                action.Action();
                print("Solved puzzle");
            }

            else if (inputCode.Length < code.Length)
            {
                text.SetText(inputCode);
            }

            else if (inputCode.Length >= code.Length)
            {
                inputCode = "";
                text.SetText("Wrong!");
                print("Try again");
            }
        }
    }
}
