using UnityEngine;

/*
Manages players interactions with objects
Written by Daniel Kasprzyk
*/

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 5f;
    public float moveForce = 250f;
    public Transform holdParent;
    public Camera cam;
    public LayerMask ignoreLayer;
    public GameObject heldObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (heldObj == null)
            {
                LayerMask rayLayer = ~ignoreLayer;
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

                if (Physics.Raycast(ray, out hit, pickupRange, rayLayer) && hit.transform.tag != "StaticObj")
                {
                    PickupObject(hit.transform.gameObject);
                }
            }

            else
            {
                DropObject();
            }
        }

        if (heldObj != null)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    private void PickupObject(GameObject pickObj)
    {
        Rigidbody objRig = pickObj.GetComponent<Rigidbody>();

        if (objRig != null)
        {
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    private void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();

        if (heldRig != null)
        {
            heldRig.useGravity = true;
            heldRig.drag = 1;
            
            heldObj.transform.parent = null;
            heldObj = null;
        }
    }

    public void ExploitFix()
    {
        if (heldObj != null)
        {
            Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();

            if (heldRig != null)
            {
                heldRig.useGravity = true;
                heldRig.drag = 1;
            
                heldObj.transform.parent = null;
                heldObj = null;
            }
        }
    }
}
