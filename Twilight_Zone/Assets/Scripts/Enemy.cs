using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
        private NavMeshAgent navMesh;
        public GameObject DeathSmoke;
        public float DeathTimer = 0.1f;
        private float timer = 0.0f;

        public float MinDistAttack = 1.0f;

        public float AttackCoolDown = 2.0f;
    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    new private void FixedUpdate() 
    {
        base.FixedUpdate();
        timer += Time.fixedDeltaTime;

        Vector3 destPos = GameObject.FindWithTag("Player").transform.position;
        navMesh.SetDestination(destPos);
        AnimatorStateInfo  lStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(Vector3.Distance(destPos, transform.position) < MinDistAttack && timer > AttackCoolDown)
        {
            timer = 0.0f;
            anim.SetTrigger("Jump");
            hit();
        }
    }
     override public void loseBlood(int damage)
    {   
        base.loseBlood(damage); 
        if (hp <= 0)
        {          
            if(DeathSmoke)
            {
                GameObject ltest = Instantiate(DeathSmoke, transform.position, transform.rotation);
            }
            Destroy(gameObject,DeathTimer); 
                       
        }
    }
}
