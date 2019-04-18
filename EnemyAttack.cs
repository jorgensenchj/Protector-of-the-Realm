using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

    public GameObject target;
    public Transform flank;
    [SerializeField] float distanceOfTarget;
    public Animator anim;
    public bool Attacking;
    public bool Running;
    NavMeshAgent myNavMeshAgent;

    // Use this for initialization
    void Start ()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Attacking = false;
        anim.SetBool("Attacking", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        target = GetComponentInChildren<Radar>().targetThreat;
        if (target != null && GetComponent<EnemyDamage>().isDead == false)
        {
            IfTargeting();
        }
	}
    void IfTargeting()
    {
        distanceOfTarget = Vector3.Distance(target.transform.position, transform.position);
        flank = target.GetComponent<PlayerAttack>().flank.transform;
        if (target.GetComponent<PlayerAttack>().target != gameObject)
        {
            myNavMeshAgent.SetDestination(flank.transform.position);
            transform.LookAt(target.transform);
        }
       else if (target.GetComponent<PlayerAttack>().target == gameObject)
        {
            myNavMeshAgent.SetDestination(target.transform.position);
            transform.LookAt(target.transform);
        }
       
       

        if (distanceOfTarget >  1.5)
        {
            Running = true;
            Attacking = false;
            anim.SetBool("Running", true );
            anim.SetBool("Attacking", false);
        }
        else if (distanceOfTarget <= 1.5)
        {
            Attacking = true;
            Running = false;
            anim.SetBool("Attacking", true);
            anim.SetBool("Running", false);
        }
    }
}
