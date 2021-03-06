﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //public Transform firePoint;

    //Confiig
    [SerializeField] float speed = 100f;
    [SerializeField] float jumpSpeed = 15f;
    //[SerializeField] float climbSpeed = 15f;
    [SerializeField] Vector2 deathKick = new Vector2(0f, 0f);
    [SerializeField] Animator myAnimator;


    // State
    bool isAlive = true;
    float controlThrow;
    bool facingRight = true;
    

    Vector2 moveVelocity;

    //Cached Components References
    Rigidbody2D myBody;

    PolygonCollider2D myFeet;
    float gravityScaleAtStart;
    BoxCollider2D myCollider;
    public GameObject myWeapon;
    public GameObject attackButton;

    //For Health
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject deathUI;

    // Start is called before the first frame update
    void Start()
    {
        
        
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myFeet = GetComponent<PolygonCollider2D>();
        //myCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myBody.gravityScale;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        myWeapon.SetActive(false);
        attackButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isAlive)
        {
            return;
        }
        Run();
        Jump();
        //FlipCharacterFace();
        // Climbing();
        Die();
        if (controlThrow < 0 && facingRight)
        {
            UpdateDirection();
        }
        else if(controlThrow > 0 && !facingRight)
        {
            UpdateDirection();
        }
        HealthBarDamage();
        

    }
    
    private void Die()
    {
        /*if (myFeet.IsTouchingLayers(LayerMask.GetMask("Death")) )
        {
            isAlive = false;
            StartCoroutine(loadDeathUI());
            //myAnimator.SetTrigger("FloatingDie");
            //GetComponent<Rigidbody2D>().velocity = deathKick;
        }*/
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Hardles")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Death");
            StartCoroutine(loadDeathUI());
            //GetComponent<Rigidbody2D>().velocity = deathKick;
        }

    }
    public IEnumerator loadDeathUI()
    {
        yield return new WaitForSeconds(0.5f);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Run()
    {
        controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * speed, myBody.velocity.y);
        myBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);

        
    }

    /* private void Climbing()
     {
         if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
         {
             //myAnimator.SetBool("Climbing", false);
             myBody.gravityScale = gravityScaleAtStart;
             return;
         }

         float controlThrow = Input.GetAxis("Vertical");
         Vector2 climbVelocity = new Vector2(myBody.velocity.x, controlThrow * climbSpeed);
         myBody.velocity = climbVelocity;
         myBody.gravityScale = 0f;

         bool playerHasVerticalSpeed = Mathf.Abs(myBody.velocity.y) > Mathf.Epsilon;
         //myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
     }*/

    void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
           
            //myBody.gravityScale = gravityScaleAtStart;
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myBody.velocity += jumpVelocityToAdd;
            //bool playerHasVerticalSpeed = Mathf.Abs(myBody.velocity.y) > Mathf.Epsilon;
            //myAnimator.SetBool("Jump", true);
          
        }
        /*else
        {
            //myAnimator.SetBool("Jump", false);
        }*/
        
          
       
        
        //myAnimator.SetBool("Jump", playerHasVerticalSpeed);
    }



    /*private void FlipCharacterFace()
    {
        //bool playerHasHorizontalSpeed = Mathf.Abs(myBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myBody.velocity.x), 1f);
        }
    }*/
    private void UpdateDirection()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void HealthBarDamage()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Death")))
        {
            StartCoroutine(JustWait());
            
        }
        else if (myFeet.IsTouchingLayers(LayerMask.GetMask("SkullStone")))
        {
            StartCoroutine(JustWait2());

        }
        if (currentHealth<=0)
        {
            deathUI.SetActive(true);
            //Time.timeScale = 0f;
        }
    }
    public IEnumerator JustWait()
    {
        TakeDamage(10);
        yield return new WaitForSeconds(1f);
        
    }
    public IEnumerator JustWait2()
    {
        TakeDamage(2);
        yield return new WaitForSeconds(1f);

    }
}
