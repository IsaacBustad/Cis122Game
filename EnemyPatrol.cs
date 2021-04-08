using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnemyNamespace
{
    public class EnemyPatrol : Enemy
    {
        //variables
        public Transform[] path;
        public int currentPoint;
        public int patrolType = 0; //controls which version of the partol script you will be using
        private const float roundingDistance = 0.01f; //float for rounding
        public float idleSpeedMultiplier = 0.5f;
        public float idleSpeed;
                                                      // Start is called before the first frame update
        void Start()
        {
                     idleSpeed = idleSpeedMultiplier * moveSpeed; //composite variable for faster calculations
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (AiPriority <= 1) //check to see if it has AI prescedence
            {
                AiPriority = 1; //cannot fail. Also will never deactivate itself.
                if (Vector3.Distance(path[currentPoint].position, transform.position) > roundingDistance) //if not already at point
                {
                    transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, idleSpeed  * Time.deltaTime); //go there

                }
                else
                {
                    currentPoint = ChangePoint();
                }
            } 
        }
        //methods
        private int ChangePoint() //probably make this a proper method with overrides later
        {
            if (patrolType == 0)
            {
                if (currentPoint == path.Length - 1) //if at ending point
                {
                    //reset target point  to beginning of loop
                    return 0;

                }
                else
                {
                    return currentPoint+1; //go to next point
                }
            }
            else if (patrolType == 1)
            {
                return Random.Range(0, path.Length - 1); //return a random point to go to next as current point. 
                                                         //this means it can repeatedly select its current destination point as a new random point. to be fixed later.
            }

            else
            {
                return currentPoint+1; //temporary
            }
        }
    }
}
