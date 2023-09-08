using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test_UI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI testAttack;


    public Text playerCheckTxt;

    private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = this.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("BBB");
        }

        testAttack.text = playerMovement.attackCount.ToString();
        playerCheckTxt.text = playerMovement.playerOverlapped.ToString();
    }





}
