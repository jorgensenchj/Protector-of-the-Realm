using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rearHitSphere : MonoBehaviour {

    public float rearSphereRange = 1;
    public GameObject trooper = null;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()

    {
        var badguy = GameObject.FindGameObjectWithTag("Enemy");
        Collider[] hits = Physics.OverlapSphere(gameObject.transform.position, rearSphereRange);

        foreach (Collider hit in hits)
        {
            if (hit.tag == "Trooper")
            {
                trooper = hit.gameObject;
            }
            if (hit.tag == "Player")
            {
                trooper = hit.gameObject;
            }
        }
        
        if (trooper != null)
        {
            float distanceOfTarget = Vector3.Distance(trooper.transform.position, transform.position);
            if ( distanceOfTarget >= 2)
            {
                trooper = null;
            }
        }
    }

            void OnDrawGizmos()
    {

        //Draw attack shpere
        Gizmos.color = new Color(255f, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, rearSphereRange);
    }

}
