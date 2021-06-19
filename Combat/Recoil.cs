using UnityEngine;

/*
Adds rotations to camera for a recoil effect
Written by Daniel Kasprzyk
*/

public class Recoil : MonoBehaviour
{
    /*[Header("Vertical Recoil")]
    public float verticalRangeMin;
    public float verticalRangeMax;

    [Header("Horizontal Recoil")]
    public float horizontalRange;
    public float duration;

    //Variables
    private float time;
    private float verticalRecoil;
    private float horizontalRecoil;

    //References
    public GameObject cam;

    private void Start()
    {
        Weapon weapon = GetComponent<Weapon>();
        cam = weapon.cam.gameObject;
    }

    public void GenerateRecoil()
    {
        time = duration;
        verticalRecoil = Random.Range(verticalRangeMin, verticalRangeMax);
        horizontalRecoil = Random.Range(-horizontalRange, horizontalRange);
        print("Generated recoil");
    }

    private void Update()
    {
        if (time > 0)
        {
            //cam.xRotation -= ((verticalRecoil / 10) * Time.deltaTime) / duration;
            //cam.yRotation -= ((horizontalRecoil / 10) * Time.deltaTime) / duration;

            //cam.transform.rotation.x -= ((verticalRecoil / 10) * Time.deltaTime) / duration;
            //Vector3 vertical = new Vector3(((verticalRecoil / 10) * Time.deltaTime) / duration, 0, 0);
            //cam.transform.localRotation += Quaternion.Euler(vertical);
            //cam.transform.rotation -= Quaterion.Angle(vertical);
            //cam.yRotation -= ((horizontalRecoil / 10) * Time.deltaTime) / duration;

            float vertRecoil = 0;
            vertRecoil -= ((verticalRecoil / 10) * Time.deltaTime) / duration;

            transform.localEulerAngles += vertRecoil;
            //transfomr.localEulerAngles += horizonRecoil;

            time -= Time.deltaTime;
        }
    }*/

    /*public float verticalRecoilMin;
    public float verticalRecoilMax;

    public float horizontalRecoilMin;
    public float horizontalRecoilMax;

    public GameObject cam;

    private void Start()
    {
        Weapon weapon = GetComponent<Weapon>();
        cam = weapon.cam.gameObject;
    }

    public void GenerateRecoil()
    {

    }*/

    /*public Vector3 upRecoil;
    private Vector3 originalRotation;

    private void Start()
    {
        originalRotation = transform.localRotation;
    }*/


}
