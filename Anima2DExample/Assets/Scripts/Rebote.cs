using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{

     private Rigidbody2D rb; //rigidbody de la plataforma
     public float jumpForce = 1; //la fuerza pa saltar jeje

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>(); //obtengo el componente de lo que colisiona 
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
           
        }

    }
    
}
