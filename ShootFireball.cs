﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    // hold hero instance
    public Hero myHero;

    // fire ball game obj prefab
    [SerializeField] private GameObject fireBallProjectile;

    // set projectile speed
    public float fireBallSpeed;
    // set throw duration
    public float throwDuration;
    public Vector2 directionToFire;



    // check for key press
    void Update()
    {
        if(Input.GetButtonDown("FireBall"))
        {
            CastFireBall();

        }
    }


    public void CastFireBall()
    {
        this.directionToFire.x = this.myHero.animator.GetFloat("Horizontal");
        this.directionToFire.y = this.myHero.animator.GetFloat("Vertical");
        this.myHero.playerState = PlayerState.cast;
        this.myHero.DoNotMove();
        this.myHero.animator.SetBool("Casting", true);
        this.StartCoroutine(SpellAndEnd());
        //myHero.animator.SetBool("Casting", false);
        //myHero.playerState = PlayerState.walk;
        

    }


    // defines spell actions and ends state
    private IEnumerator SpellAndEnd()
    {
        GameObject aFireBall = Instantiate(
                    fireBallProjectile,
                    transform.position,
                    Quaternion.identity) as GameObject;

        aFireBall.GetComponent<Rigidbody2D>().velocity = this.directionToFire * this.fireBallSpeed;
        yield return new WaitForSeconds(this.throwDuration);
        myHero.animator.SetBool("Casting", false);
        myHero.playerState = PlayerState.walk;
    }

    


}
