using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform player;
    private float mouseSpeed = 400;
    private float xRot;
    private float yRot;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        xRot -= mouseY;
        yRot += mouseX;

        xRot = Mathf.Clamp(xRot, -70f, 70f);
        cam.transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        player.transform.rotation = Quaternion.Euler(0, yRot, 0);

    }
}
