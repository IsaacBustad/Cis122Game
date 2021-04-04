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

    // dash specific
    [SerializeField] public float dashTime;
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashCoolDown;
    [SerializeField] private bool doubleTapThreshUp = false;
    [SerializeField] private bool doubleTapThreshDown = false;
    [SerializeField] private bool doubleTapThreshRight = false;
    [SerializeField] private bool doubleTapThreshLeft = false;
    [SerializeField] private string lastMoveKey = "";
    [SerializeField] private float lastTapTime;
    [SerializeField] public bool canDash = true;

    // controle map for future



    // components set in inspector correspond to hero body
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator animator;  
    

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
        DetectDash();
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

    //dash method
    private IEnumerator Dash()
    {
        // execute dash
        if (this.canDash == true)
        {
            // for later animatior inclusion
            this.animator.SetBool("Dashing", true);
            this.playerState = PlayerState.dash;
            this.rb.velocity = this.movement * moveSpeed * this.dashSpeed;
            
            yield return new WaitForSeconds(this.dashTime);
            this.canDash = false;
        }
        
        
        // allow player controle again
        this.playerState = PlayerState.walk;
        // for later animatior inclusion
        this.animator.SetBool("Dashing", false);
        // delay dash use
        yield return new WaitForSeconds(this.dashCoolDown);
        this.canDash = true;
    }

    private IEnumerator ManThrestUp()
    {
        doubleTapThreshUp = true;
        yield return new WaitForSeconds(.2f);
        doubleTapThreshUp = false;
    }

    private IEnumerator ManThrestDown()
    {
        doubleTapThreshDown = true;
        yield return new WaitForSeconds(.2f);
        doubleTapThreshDown = false;
    }

    private IEnumerator ManThrestLeft()
    {
        doubleTapThreshLeft = true;
        yield return new WaitForSeconds(.2f);
        doubleTapThreshLeft = false;
    }

    private IEnumerator ManThrestRight()
    {
        doubleTapThreshRight = true;
        yield return new WaitForSeconds(.2f);
        doubleTapThreshRight = false;
    }

    private void DetectDash()
    {
        if (Input.GetKeyDown("w"))
        {
            if (this.doubleTapThreshUp == true && this.lastMoveKey == "w")
            {
                StartCoroutine(Dash());
            }

            else
            {
                this.lastMoveKey = "w";
                StartCoroutine(ManThrestUp());
            }
        }
        else if (Input.GetKeyDown("s"))
        {
            if (this.doubleTapThreshDown == true && this.lastMoveKey == "s")
            {
                StartCoroutine(Dash());

            }

            else
            {
                this.lastMoveKey = "s";
                StartCoroutine(ManThrestDown());
            }
        }
        else if (Input.GetKeyDown("d"))
        {
            if (this.doubleTapThreshRight == true && this.lastMoveKey == "d")
            {
                StartCoroutine(Dash());
            }

            else
            {
                this.lastMoveKey = "d";
                StartCoroutine(ManThrestRight());
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (this.doubleTapThreshLeft == true && this.lastMoveKey == "a")
            {
                StartCoroutine(Dash());
            }

            else
            {
                this.lastMoveKey = "a";
                StartCoroutine(ManThrestLeft());
            }
        }

    }




    // open for test
    


    


}
