using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public GameObject player;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        
    }
}
