using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeDash : MonoBehaviour
{
    // dash specific vars
    [SerializeField] public float dashTime;
    [SerializeField] public float dashSpeed;
    [SerializeField] public float dashCoolDown;
    [SerializeField] private bool doubleTapThreshUp = false;
    [SerializeField] private bool doubleTapThreshDown = false;
    [SerializeField] private bool doubleTapThreshRight = false;
    [SerializeField] private bool doubleTapThreshLeft = false;
    [SerializeField] private string lastMoveKey = "";    
    [SerializeField] public bool canDash = true;

    // hold hero instance
    public Hero myHero;

    // direction to dash
    Vector2 direction = new Vector2();

    // methods
    // called every update
    void Update()
    {
        DetectDash();
    }

    //dash method
    private IEnumerator Dash()
    {
        this.direction.x = this.myHero.animator.GetFloat("Horizontal");
        this.direction.y = this.myHero.animator.GetFloat("Vertical");

        // execute dash
        if (this.canDash == true)
        {
            // for later animatior inclusion
            this.myHero.animator.SetBool("Dashing", true);
            this.myHero.playerState = PlayerState.dash;
            this.myHero.rb.velocity = this.myHero.moveSpeed * this.direction * this.dashSpeed;

            yield return new WaitForSeconds(this.dashTime);
            this.canDash = false;
        }


        // allow player controle again
        this.myHero.playerState = PlayerState.walk;
        // for later animatior inclusion
        this.myHero.animator.SetBool("Dashing", false);
        // delay dash use
        yield return new WaitForSeconds(this.dashCoolDown);
        this.canDash = true;
    }

    private IEnumerator ManThrestUp()
    {
        this.doubleTapThreshUp = true;
        yield return new WaitForSeconds(.2f);
        this.doubleTapThreshUp = false;
    }

    private IEnumerator ManThrestDown()
    {
        this.doubleTapThreshDown = true;
        yield return new WaitForSeconds(.2f);
        this.doubleTapThreshDown = false;
    }

    private IEnumerator ManThrestLeft()
    {
        this.doubleTapThreshLeft = true;
        yield return new WaitForSeconds(.2f);
        this.doubleTapThreshLeft = false;
    }

    private IEnumerator ManThrestRight()
    {
        this.doubleTapThreshRight = true;
        yield return new WaitForSeconds(.2f);
        this.doubleTapThreshRight = false;
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

}
