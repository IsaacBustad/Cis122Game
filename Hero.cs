// creator Isaac Bustad
// created 3/11/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// make states
public enum PlayerState
{
    walk,
    sword,
    dash,
    cast,
    stunned,
    interact
}


public class Hero : MonoBehaviour
{
    
    
    // component for movement and animation in script
    // playerState is for changing chatacter state and accessible actions
    public PlayerState playerState;
    [SerializeField] public float moveSpeed;

    

    // controle map for future



    // components set in inspector correspond to hero body
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator animator;  
    

    //vector2 to multiply with speed to determine velocity to move character
    public Vector2 movement;





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
        
        if (Input.GetButton("Sword"))
        {
            SwingSword();
        }
        
        else if (playerState == PlayerState.walk)
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
            this.animator.SetBool("IsMoving", true);
            Move();
        }
        else
        {
            this.animator.SetBool("IsMoving", false);
            DoNotMove();
        }
        
    }

    private void Move()
    {        
        
        this.rb.velocity = (this.movement * this.moveSpeed);
        
    }

    // cancel velocity
    public void DoNotMove()
    {
        this.rb.velocity = this.movement * 0;
    }

    
    // public to set in animations
    // new swing sword uses event in animator to end
    private void SwingSword()
    {
        DoNotMove();
        this.animator.SetBool("SwingingSword", true);
        this.playerState = PlayerState.sword;
    }

    // accessed in animation to
    private void SetNotAttacking()
    {
        this.animator.SetBool("SwingingSword", false);
        this.playerState = PlayerState.walk;
    }

    




    // open for test
    


    


}
