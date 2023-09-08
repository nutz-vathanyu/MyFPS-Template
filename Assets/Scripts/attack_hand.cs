using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_hand : MonoBehaviour
{
    public PlayerMovement playerMovement;

    [SerializeField]
    private GameObject myPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("player") && collision.gameObject != myPlayer)
        {
            if (playerMovement.isAttacking)
            {
                ++playerMovement.attackCount;

            }
        }
    }


}
