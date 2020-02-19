
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    [SerializeField] bool jump = false;
    [SerializeField]  bool crouch = false;
    public float Gravity2D = -30f;
    public int FacingRight => controller.m_FacingRight ? 1 : -1;
    private void ChangeGravity(float g)
    {
    }

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        Physics2D.gravity = new Vector2(0, Gravity2D);
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
       animator.SetBool("IsJumping", false); 
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

    }
} 