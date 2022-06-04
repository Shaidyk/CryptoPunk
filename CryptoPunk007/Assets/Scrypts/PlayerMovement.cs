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
        // Проверка на земле или нет
        isGrounded = Physics.CheckSphere(groundChec.position, groundDistance, groundMask);

        // Обнуление гравитации
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.8f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Движение
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Гравитация
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Приседание
        if (Input.GetKey("c"))
        {
            controller.height = 0.8f;
        }
        else
        {
            controller.height = 1.6f;
        }


        // Ускорение
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
