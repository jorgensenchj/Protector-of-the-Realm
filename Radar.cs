using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

    public List<GameObject> enemiesinrange;
    public bool threat;
    public GameObject targetThreat;
    public GameObject self;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemiesinrange.Count == 0)
        {
            targetThreat = null;
        }
         if (enemiesinrange.Count <= 1 && targetThreat == null)
        {
            RunTargetFirst();
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!enemiesinrange.Contains(collider.gameObject))
            {
                enemiesinrange.Add(collider.gameObject);
                if (targetThreat == null)
                {
                    targetThreat = collider.gameObject;
                }
                else if (targetThreat != null)
                {
                    if (targetThreat.GetComponent<PlayerAttack>().target != self)
                    {
                        if (collider.gameObject.GetComponent<PlayerAttack>().target == self)
                        {
                            targetThreat = collider.gameObject;
                        }
                    }

                }
                
            }
              
        }
        
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (enemiesinrange.Contains(collider.gameObject))
            {
                enemiesinrange.Remove(collider.gameObject);
                targetThreat = null;
                RunTargetFirst();
            }
        }
        
    }
    void RunTargetFirst()
    {



        for (int i = 0; i < enemiesinrange.Count; i++)
        {
            Debug.Log("enemy number: " + i);
            if (enemiesinrange[i].GetComponent<PlayerAttack>().target != self)
            {
                targetThreat = enemiesinrange[i];
            }
            else if(enemiesinrange[i].GetComponent<PlayerAttack>().target == self)
            {
                targetThreat = enemiesinrange[i];
            }

        } 
    }

  }
