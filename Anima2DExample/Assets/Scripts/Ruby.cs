using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
   
    public SpriteRenderer ruby;
    
    public Rigidbody2D rigidbody;
    
    public float moveSpeed;
    public float jumpForce = 1;


    public int currentHP = 30;
    public int HP = 30;

    private float horizontal;
    private float vertical;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Salto de personaje
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        //Movimiento del Personaje
        //a -> Left
        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

        //d -> Right
        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            transform.localScale = new Vector3(-1, -1, -1);

            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        if (direction.magnitude == 0f)
        {
            animator.SetBool("RunSide", false);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().DamageAmount) < 0)
                currentHP = 0;
            else
                currentHP -= collision.GetComponent<Hazard>().DamageAmount;
            animator.SetTrigger("HitSide");
        }
        if (collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().HealAmount) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().HealAmount;
            //activar heal particles 

        }
        if (collision.CompareTag("Enemy"))
        {
            if ((currentHP - collision.GetComponent<Enemy>().DamageInflict) < 0)
                currentHP = 0;
            else
                currentHP -= collision.GetComponent<Enemy>().DamageInflict;
            animator.SetTrigger("HitSide");
        }
    }
}
