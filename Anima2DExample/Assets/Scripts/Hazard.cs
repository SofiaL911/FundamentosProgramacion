﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int DamageAmount;
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWithPlayer(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //activar animacion 
        }


    }






}