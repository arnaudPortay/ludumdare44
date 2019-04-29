using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
        private NavMeshAgent navMesh;

        private float timer = 0.0f;

        public float MinDistAttack = 1.0f;

        public float AttackCoolDown = 2.0f;
    // Start is called before the first frame update
    void Awake()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() 
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
        }
    }
     override public void loseBlood(int damage)
    {   
        base.loseBlood(damage); 
        if (hp <= 0)
        {                 
            Destroy(gameObject,0);             
        }
    }
}
