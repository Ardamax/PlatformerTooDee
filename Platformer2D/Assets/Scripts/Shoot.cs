using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    // crosshair
    public Vector2 aim;
    public GameObject crosshair;
    public float crosshairDistance;

    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        Crosshair();
    }


    void Crosshair()
    {
        aim = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButton("Fire1"))
        {
            aim.Normalize();
            aim *= crosshairDistance;
            crosshair.transform.localPosition = aim;
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(false);
        }
    }

}
