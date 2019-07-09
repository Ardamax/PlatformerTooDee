using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject player;
    private bool isMouse = true;

    private void FixedUpdate()
    {

        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0)
        {
            isMouse = true;
        }
        else if (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0)
        {
            isMouse = false;
        }
        

        if (isMouse)
        {
            Debug.Log("MOUSE INPUT");

            Vector3 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            distance.Normalize();

            float rotationZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            if (rotationZ < -90 || rotationZ > 90)
            {
                if (player.transform.eulerAngles.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
                }
                else if (player.transform.eulerAngles.y == 180)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
                }
            }
        }

        if (!isMouse)
        {
            Debug.Log("CONTROLLER INPUT");
            var joystickX = Input.GetAxis("Horizontal");
            var joystickY = Input.GetAxis("Vertical");

            float rotationZ = Mathf.Atan2(joystickY, joystickX) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            if (rotationZ < -90 || rotationZ > 90)
            {
                if (player.transform.eulerAngles.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
                }
                else if (player.transform.eulerAngles.y == 180)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
                }
            }
        }

    }




}
