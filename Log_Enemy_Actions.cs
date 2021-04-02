using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Enemy_Actions : MonoBehaviour
{
    private enum LogEnemyState
    {
        attacking,
        resting,
        moving
    }



    // component for movement and animation in script
    // currentState is for changing chatacter state and accessible actions
    private LogEnemyState logEnemyState;
    [SerializeField] private float moveSpeed;

    // dash specific
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCoolDown;        
    [SerializeField] private bool canDash = true;


    // components set in inspector correspond to hero body
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;


    //vector2 to multiply with speed to determine velocity to move character
    private Vector2 movement;



    // Methods
    // Update is called once per frame
    void Update()
    {
        SenseInput();

    }

    // sense movement set States
    private void SenseInput()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");
        
        if (logEnemyState == LogEnemyState.moving)
        {
            UpdateAnimationAndMove();
        }
    }


    // update animator variables
    private void UpdateAnimationAndMove()
    {
        if (movement != Vector2.zero)
        {
            this.animator.SetFloat("Horizontal", this.movement.x);
            this.animator.SetFloat("Vertical", this.movement.y);
            this.animator.SetBool("Moving", true);
            Move();
        }
        else
        {
            this.animator.SetBool("Moving", false);
            DoNotMove();
        }

    }


    private void Move()
    {

        this.rb.velocity = (this.movement * this.moveSpeed);

    }

    // cancel velocity
    private void DoNotMove()
    {
        this.rb.velocity = this.movement * 0;
    }


    // public to set in animations
    

    //dash method
    private IEnumerator Dash()
    {
        // execute dash
        if (this.canDash == true)
        {
            // for later animatior inclusion
            this.animator.SetBool("Attacking", true);
            this.logEnemyState = LogEnemyState.attacking;
            this.rb.velocity = this.movement * this.dashSpeed;

            yield return new WaitForSeconds(this.dashTime);
            this.canDash = false;
        }


        // allow player controle again
        this.logEnemyState = LogEnemyState.moving;
        // for later animatior inclusion
        this.animator.SetBool("Attacking", false);
        // delay dash use
        yield return new WaitForSeconds(this.dashCoolDown);
        this.canDash = true;
    }

    
   
}