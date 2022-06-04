using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundChec;
    public LayerMask groundMask;
    public Image UIHp;
    
    Vector3 velocity;
    Animator anim;

    public float speed = 5f;
    public float gravity = 9.8f * 3f;
    public float jumpHeight = 1.5f;
    public float groundDistance = 0.07f;

    public float hp = 1f;

    bool isGrounded;

    float x;
    float z;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        UIHp.fillAmount = hp;

        // Проверка на земле или нет
        isGrounded = Physics.CheckSphere(groundChec.position, groundDistance, groundMask);

        // Обнуление гравитации
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.8f;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }


        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        // Движение
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetKey(KeyCode.W))
        {
        }
        if (Input.GetKey(KeyCode.A))
        {
        }
        if (Input.GetKey(KeyCode.S))
        {
        }
        if (Input.GetKey(KeyCode.D))
        {
        }
        

        // Гравитация
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            anim.SetTrigger("Jump");
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
            anim.SetTrigger("Sprint");
        }
        else
        {
            speed = 5f;
            anim.SetTrigger("Idle");
        }
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", x, 0f, Time.deltaTime);
        anim.SetFloat("Direction", z, 0f, Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DamageBox")
        {
            hp -= Time.deltaTime / 10;
        }
    }
}
