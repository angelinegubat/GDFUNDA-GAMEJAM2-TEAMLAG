using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float Speed = 650.0f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject Paused;
    public GameObject Sick;
    public GameObject Faint;
    public GameObject Corona;
    public GameObject Missed;
    public GameObject SS;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        if (!Paused.active && !Sick.active && !Faint.active && !Corona.active && !SS.active && !Missed.active)
        {
            float mouseX = Input.GetAxis("Mouse X") * Speed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Speed * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
    }
}
