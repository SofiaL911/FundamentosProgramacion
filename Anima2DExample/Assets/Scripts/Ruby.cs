using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;
    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private int currentHP = 30;
    [SerializeField]
    private int HP = 30;

    //private int HP = 30;
    // private int currentHP = 30; Esta en el Script Hazard


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //w -> Back
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("RunBack",true);
            animator.SetBool("RunFront",false);
            animator.SetBool("RunSide",false);
            transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed);
        }
        //s -> Front
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", true);
            animator.SetBool("RunSide", false);
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed);
        }
        //a -> Left

        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;

            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

        //d -> Right
        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;

            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().DamageAmount) < 0)
                currentHP = 0;
            else
            currentHP -= collision.GetComponent<Hazard>().DamageAmount;
            animator.SetTrigger("HitSide");
        }
        if(collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().HealAmount) > HP)
                currentHP = HP;
            else
            currentHP += collision.GetComponent<Heal>().HealAmount;
            //activar heal particles 

        }

    }

}
