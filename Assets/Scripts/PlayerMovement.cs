using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{




    [SerializeField]
     float rotationSpeed=50f;
    [SerializeField]
    float playerSpeed=5f;


    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool _isGrounded;

    public float jumpHeight = 1.0f;

    private float gravityValue = Physics.gravity.y;

    private Vector2 inputVector;


    public Vector2 currentMovementInput { get; set; }
    public Vector3 currentMovement;
   public bool isMoveMentPressed { get; set; }


    



    Animator animator;

    private float rotationFactorPerFrame = 1f;


    PlayerInput playerInput;



    private Animation legacyAnimation;
    private string curStateName = "";



    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask playerMask;
   public bool isGrounded { get; set; }
   public bool playerOverlapped { get; set; }

    bool anim_landing;


 


    public bool isJumping { get; set; }

    bool isTouchingGround;

    bool landingCheck;

    bool isFalling;

    public bool isAttacking { get; set; }

    public float attackCount;




    public event Action StartLanding = delegate { };
    public event Action StopLanding = delegate { };

    public event Action StartJump = delegate { };
    public event Action StopJump = delegate { };
   


    private void Awake()
    {
        GetComponent<InputController>().StartAttack += StartAttack;
        GetComponent<InputController>().StopAttack += StopAttack;
        GetComponent<InputController>().StartJump += m_StartJump;

        animator = GetComponent<Animator>();     

        legacyAnimation = GetComponent<Animation>();

        characterController = GetComponent<CharacterController>();

    }

    void Start()
    {
        isFalling = true;
        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        characterController.Move(playerVelocity * Time.fixedDeltaTime);
    }



    void Update()
    {

        if (currentMovement != Vector3.zero)
            MovementCalc();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        playerOverlapped = Physics.CheckSphere(groundCheck.position, groundDistance, playerMask);

        if(isGrounded  && playerVelocity.y <0)

        {
                playerVelocity.y = -2;
           
            if (!animator.GetBool("Landing") && isJumping)
            {
                StopJump();
                StartLanding();

                isJumping = false;
            }

        }
    

        if(playerVelocity.y <  -2.1)
        {
            StartJump(); 
            isJumping = true;
            StopLanding();
        }


    }




    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "player")
        {
          
            PlayerOverlappedCheck();
        }

    }



    void StartAttack()
    {
       isAttacking = true;
        Vector3 Movement = transform.forward * 1;
        transform.Rotate(Vector3.up * currentMovement.x * (rotationSpeed * Time.deltaTime));
        Movement.Normalize();
        characterController.Move(Movement * playerSpeed * Time.deltaTime);
    }

    void StopAttack()
    {
        isAttacking = false;
    }


  void m_StartJump(float a)
    {
        playerVelocity.y = -2;
         isJumping = true;

        StopLanding();
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }


    void MovementCalc()
    {
        Vector3 Movement = transform.forward * currentMovement.z;
        transform.Rotate(Vector3.up * currentMovement.x * (rotationSpeed * Time.deltaTime));
        Movement.Normalize();

        characterController.Move(Movement * playerSpeed * Time.deltaTime);
    }




    void PlayerOverlappedCheck()
    {
        if (playerOverlapped)
        {
            StopJump();
            StartLanding();
            isJumping = false;
            m_StartJump(jumpHeight*0.5f);
        }
    }



}
