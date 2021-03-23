using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Mouse sensitivity
    public float mouseSensitivity = 100f;

    public Transform characterBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //loccking the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

       xRotation -= mouseY;
       //Avoiding over-rotate and looking behind the character
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);

       transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       characterBody.Rotate(Vector3.up * mouseX);
    }
}
