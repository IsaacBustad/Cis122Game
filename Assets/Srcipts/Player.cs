using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Heath
    [SerializeField] private int myHealth = 100;
    [SerializeField] private int moveSpeed;
    [SerializeField] private Animator animator;

    

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }



    private void Move()
    {
        MoveLeftOrRight();
        MoveUpOrDown();

    }

    private void MoveLeftOrRight()
    {
        var movementX = Input.GetAxis("Horizontal");
        var deltaX = movementX  * Time.deltaTime * moveSpeed;
        var newXPos = this.transform.position.x + deltaX;
        this.transform.position = new Vector2(newXPos, this.transform.position.y);
        
        this.animator.SetFloat("Horizontal", movementX);
    }

    private void MoveUpOrDown()
    {
        var movementY = Input.GetAxis("Vertical");
        var deltaY = movementY * Time.deltaTime * moveSpeed;
        var newYPos = this.transform.position.y + deltaY;
        this.transform.position = new Vector2(this.transform.position.x, newYPos);

        this.animator.SetFloat("Vertical", movementY);
    }
}
