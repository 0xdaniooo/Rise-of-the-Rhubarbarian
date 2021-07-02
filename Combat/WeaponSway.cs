using UnityEngine;

/*
Makes the weapon move around as the player walks about
Written by Daniel Kasprzyk
*/

public class WeaponSway : MonoBehaviour
{
    public float intensity = 1.5f;
    public float smooth = 20f;
    private Quaternion originRotation;

    private void Start()
    {
        originRotation = transform.localRotation;
    }

    private void Update()
    {
        UpdateSway();
    }

    private void UpdateSway()
    {
        //Controls
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Calculate target rotation
        Quaternion adjX = Quaternion.AngleAxis(-intensity * mouseX, Vector3.up);
        Quaternion adjY = Quaternion.AngleAxis(intensity * mouseY, Vector3.right);
        Quaternion targetRotation = originRotation * adjX * adjY;

        //Rotate towards target rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }
}
