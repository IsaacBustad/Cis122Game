//Steven Pichelman
//3/28/2021
//EnemyMelee child class
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnemyNamespace
{
    public class EnemyMelee : Enemy
    {
        public Transform target, homePosition; //basically a xyz rotation etc for it to target and for it to go back to. We only care about position
        public float attackRadius, chaseRadius;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindWithTag("Player").transform; //target becomes location of player. This also becomes updated automatically as player moves
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (AiPriority <= 2) //check to see if script can have priority to run
            {
                CheckDistance();
            }

        }
        void CheckDistance()
        {
            var distanceFromTarget = Vector3.Distance(target.position, transform.position);

            if (distanceFromTarget <= chaseRadius && distanceFromTarget > attackRadius - 0.1)
            //check distance between it and the player against the chaseRadius. Get target within the attack radius and stop
            {
                AiPriority = 2;
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                //use MoveTowards built-in method to move enemyMelee towards target position within its attack radius margin of error
            }
            else
            {
                AiPriority = 1; //return to a lower AI state.
            }
        }
    }
}
