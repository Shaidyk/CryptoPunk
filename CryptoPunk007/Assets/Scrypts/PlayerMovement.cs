using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundChec;
    public LayerMask groundMask;
    public float speed = 5f;
    public float gravity = 9.8f * 3f;
    public float jumpHeight = 1.5f;
    public float groundDistance = 0.07f;
    Vector3 velocity;
    bool isGrounded;


    void Update()
    {
        // �������� �� ����� ��� ���
        isGrounded = Physics.CheckSphere(groundChec.position, groundDistance, groundMask);

        // ��������� ����������
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.8f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // ��������
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // ����������
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // ����������
        if (Input.GetKey("c"))
        {
            controller.height = 0.8f;
        }
        else
        {
            controller.height = 1.6f;
        }


        // ���������
        if (Input.GetKey("left shift"))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
    }
}
