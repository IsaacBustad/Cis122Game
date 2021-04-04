// creator Isaac Bustad
// created 3/11/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private int heroHealth = 100;
    [SerializeField] private float moveSpeed;
    // last direction faced
    private int lastDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    // properties
    //last direction needs to be set by animation in inspector
    public int LastDirection
    {
        set
        {
            this.lastDirection = value;
        }
    }
    

    //vector2 to add to transform possition to move character
    private Vector2 movement;



    // Methods
    // Update is called once per frame
    void Update()
    {
        // If statemnet created for stamina purpose only!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StaminaBar.instance.UseStamina(15);
        }
        SenseMoveInput();
    }

    /*void FixedUpdate()
    {
        Move();
    }*/

    private void SenseMoveInput()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", movement.sqrMagnitude);

        

        if (movement != Vector2.zero)
        {
            Move();
            animator.SetFloat("Horizontal", this.movement.x);
            animator.SetFloat("Vertical", this.movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        


    }

    private void Move()
    {
        rb.MovePosition(rb.position + this.movement * this.moveSpeed * Time.fixedDeltaTime);
    }
        
}
