using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    // hold hero instance
    public Hero myHero;


    // set vars
    /*void Start()
    {
        // get component for my hero
        myHero = gameObject.GetComponent<Hero>();
    }*/


    // check for key press
    void Update()
    {
        if(Input.GetButton("FireBall"))
        {
            CastFireBall();

        }
    }


    public void CastFireBall()
    {
        
        myHero.playerState = PlayerState.cast;
        myHero.DoNotMove();
        myHero.animator.SetBool("Casting", true);
        //myHero.animator.SetBool("Casting", false);
        //myHero.playerState = PlayerState.walk;

    }

    private IEnumerator SpellAndEnd()
    {

    }
}
