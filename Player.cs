using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Heath
    [SerializeField] private int myHealth = 100;
    [SerializeField] private int moveSpeed;

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
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void MoveUpOrDown()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        transform.position = new Vector2(transform.position.x, newYPos);
    }
}
