//Steven Pichelman
//3/28/2021
//Enemy parent class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EnemyNamespace
{
    public class Enemy : MonoBehaviour
    {
        //commonly used private variables
        public int health = 1;
        public float moveSpeed = 0;
        public Animator animator;
        //sets state of AI for taking prescedence over multiple scripts.
        // 0 is null, no AI
        //1 is idle
        //2 is chasing
        //3 is attacking
        public int AiPriority = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }
    }
}
