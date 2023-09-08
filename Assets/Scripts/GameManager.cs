using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (instance != this)
            Destroy(this.gameObject);
    }

    public  bool Attack1;



}
