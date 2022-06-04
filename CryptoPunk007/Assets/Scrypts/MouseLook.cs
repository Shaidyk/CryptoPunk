using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensativity = 130f;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // �������� ����� � ������
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensativity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensativity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -27f, 55f);  // ��������� �������� ��������
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // �������� �� Y

        playerBody.Rotate(Vector3.up * mouseX);  // �������� �� �

    }
}
