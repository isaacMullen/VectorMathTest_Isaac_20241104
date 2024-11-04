using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;

    float xRotation = 0f; 
    
    // Start is called before the first frame update
    void Start()
    {
        //Locking cursor to middle of the camera view
        Cursor.lockState = CursorLockMode.Locked;
        //Hiding the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the movement of the mouse on the X and Y axis to then aim the camera at
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //Setting our rotation on the X-Axis to our mouse location on the Y axis. Clamping it to only move 180 degrees
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Aiming the camera on the Y-Axis Manually
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Aiming the camera using the inherited reotation of the player's body
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
