using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    PlayerMovement playerMovement;

    PlayerInput playerInput;

    public event Action StartAttack = delegate { };
    public event Action StopAttack = delegate { };

    public event Action<float> StartJump = delegate { };

    public event Action StartWalk = delegate { };
    public event Action<string, float> WalkPos = delegate { };
    public event Action StopWalk = delegate { };


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


        }
        if (context.performed)
        {
            StartAttack();
        }

        if (context.canceled)
        {
            StopAttack();
        }
    }

    void OnMoveMentInput(InputAction.CallbackContext context)
    {
        playerMovement.currentMovementInput = context.ReadValue<Vector2>();
      
        
        playerMovement.currentMovement.x = playerMovement.currentMovementInput.x;
        playerMovement.currentMovement.z = playerMovement.currentMovementInput.y;
        playerMovement.isMoveMentPressed = playerMovement.currentMovementInput.x != 0 || playerMovement.currentMovementInput.y != 0;

        WalkPos("velocity x",playerMovement.currentMovement.x);
        WalkPos("velocity z", playerMovement.currentMovement.z);

        if(context.started)
        {
            StartWalk();
        }

        if(context.canceled)
        {
            StopWalk();
        }


    }

    void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }

        if (context.performed)
        {
            if (playerMovement.isGrounded && !playerMovement.isJumping)
            {
                StartJump(playerMovement.jumpHeight);
            }
        }

        if (context.canceled)
        {
        }
    }

}
