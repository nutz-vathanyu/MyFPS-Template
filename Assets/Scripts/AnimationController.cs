using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        GetComponent<InputController>().StartAttack += StartAttack;
        GetComponent<InputController>().StopAttack += StopAttack;
        GetComponent<InputController>().StartJump += StartJump;

        GetComponent<InputController>().StartWalk += StartWalk;
        GetComponent<InputController>().StopWalk += StopWalk;
        GetComponent<InputController>().WalkPos += WalkPos;

        GetComponent<PlayerMovement>().StartLanding += StartLanding;
        GetComponent<PlayerMovement>().StopLanding += StopLanding;
        GetComponent<PlayerMovement>().StartJump += StartJump;
        GetComponent<PlayerMovement>().StopJump += StopJump;

        
    }






    void StartWalk()
    {
        animator.SetBool("Walk", true);
    }

    void StopWalk()
    {
        animator.SetBool("Walk", false);
    }

    void WalkPos(string a, float b)
    {
        animator.SetFloat(a, b);
    }    


    void StartAttack()
    {
        animator.SetBool("Attack1", true);
    }

    void StopAttack()
    {
        animator.SetBool("Attack1", false);
    }

    void StartJump(float a)
    {
        animator.SetBool("Jump", true);
    }

    void StartJump()
    {
        animator.SetBool("Jump", true);
    }

    void StopJump() 
    {
        animator.SetBool("Jump", false);
    }

    void StartLanding()
    {
        animator.SetBool("Landing", true);
    }

    void StopLanding()
    {
        animator.SetBool("Landing", false);
    }

}
