using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;
    public Rigidbody2D rigidbody;

    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce = 1; 

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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);
        #region Unused
        //w -> Back
        /*if (Input.GetKey(KeyCode.W))
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
        */
        #endregion

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
        }

        //a -> Left

        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;

            //animator.SetBool("RunBack", false);
            //animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

        //d -> Right
        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;

            //animator.SetBool("RunBack", false);
            //animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        if(direction.magnitude == 0f)
        {
            animator.SetBool("RunSide", false);

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
