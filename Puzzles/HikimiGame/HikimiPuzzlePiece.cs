using UnityEngine;

/*
Allows the player to interact with hikimi puzzle pieces
Written by Daniel Kasprzyk
*/

public class HikimiPuzzlePiece : MonoBehaviour
{
    public float accuracy = 0.1f;
    public int moveSpeed = 20;
    public GameObject correctForm;
    private Camera cam;

    private bool moving;
    public bool completed;

    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;
    private HikimiGame hikimiGame;

    private void Start()
    {
        hikimiGame = GetComponentInParent<HikimiGame>();
        cam = hikimiGame.cam;

        resetPosition = this.transform.localPosition;
    }

    private void Update()
    {
        //Pick up object
        if (Input.GetMouseButton(0) && !moving && !completed)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.tag == "HikimiPiece" && hit.transform == this.transform)
                {
                    moving = true;
                    hikimiGame.PieceControl(this, false);
                }
            }
        }

        //Let go of object
        else if (Input.GetMouseButtonUp(0) && !completed)
        {
            moving = false;
            hikimiGame.PieceControl(this, true);

            if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= accuracy &&
                Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= accuracy)
            {
                this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
                completed = true;
                hikimiGame.CheckPieces();
            }

            else
            {
                this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                completed = false;
            }
        }

        //Moving object
        else if (moving)
        {
            float mouseX = -Input.GetAxisRaw("Mouse X") / moveSpeed;
            float mouseY = Input.GetAxisRaw("Mouse Y") / moveSpeed;

            Vector3 dir = new Vector3(mouseX, mouseY, 0f);
            this.transform.localPosition += dir;
        }
    }
}
