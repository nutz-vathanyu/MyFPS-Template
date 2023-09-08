using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    PlayerMovement playerMovement;

    PlayerInput playerInput;

    Animator animator;



    private void OnEnable()
    {
        playerInput.Controller.Enable();
    }

    private void OnDisable()
    {
        playerInput.Controller.Disable();
    }

    private void Awake()
    {
        playerMovement = this.GetComponent<PlayerMovement>();
        playerInput = new PlayerInput();
        animator = this .GetComponent<Animator>();

        playerInput.Controller.Movement.started += OnMoveMentInput;
        playerInput.Controller.Movement.performed += OnMoveMentInput;
        playerInput.Controller.Movement.canceled += OnMoveMentInput;

        playerInput.Controller.Jump.started += OnJumpInput;
        playerInput.Controller.Jump.performed += OnJumpInput;
        playerInput.Controller.Jump.canceled += OnJumpInput;


        playerInput.Controller.Attack.started += OnAttackInput;
        playerInput.Controller.Attack.performed += OnAttackInput;
        playerInput.Controller.Attack.canceled += OnAttackInput;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()    
    {
        
    }

    void OnAttackInput(InputAction.CallbackContext context)
    {

        if (context.started)
        {
          //  Debug.Log("Start Attack");

        }
        if (context.performed)
        {
            //  Debug.Log("Attack Performed");
            animator.SetBool("Attack1", true);

            playerMovement.AttackMovement();
            playerMovement.isAttacking = true;

        }

        if (context.canceled)
        {
            // Debug.Log("Attack Canceled");
            animator.SetBool("Attack1", false);
            playerMovement.isAttacking = false;

        }
    }

    void OnMoveMentInput(InputAction.CallbackContext context)
    {
        playerMovement.currentMovementInput = context.ReadValue<Vector2>();
      
        
        playerMovement.currentMovement.x = playerMovement.currentMovementInput.x;
      //  Debug.Log("X: " + playerMovement.currentMovement.x);
        playerMovement.currentMovement.z = playerMovement.currentMovementInput.y;
      //  Debug.Log("Y: " + playerMovement.currentMovement.z);
        playerMovement.isMoveMentPressed = playerMovement.currentMovementInput.x != 0 || playerMovement.currentMovementInput.y != 0;

        animator.SetFloat("velocity x", playerMovement.currentMovement.x);
        animator.SetFloat("velocity z", playerMovement.currentMovement.z);



        if(context.started)
        {
            // if(!playerMovement.isJumping)
            animator.SetBool("Walk", true);
        }





        if(context.canceled)
        {
            animator.SetBool("Walk", false);
        }


    }

    void OnJumpInput(InputAction.CallbackContext context)
    {
        //   animator.StopPlayback();

        if (context.started)
        {

        }

        if (context.performed)
        {
            if (playerMovement.isGrounded && !playerMovement.isJumping)
            {
                playerMovement.JumpFunc(playerMovement.jumpHeight);
                //   playerVelocity.y += Mathf.Sqrt( jumpHeight* -3.0f * gravityValue);

            }
        }

        if (context.canceled)
        {
            //      isJumping = false;
        }
    }

}
