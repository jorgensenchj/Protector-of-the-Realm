using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSelector : MonoBehaviour {

   
    public GameObject[] selectionPrefabs;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //think about destroying selection prefabs over 10 in selection after box closes
       // selectionPrefabs.Length = selectedTroops.Length;
        selectionPrefabs = GameObject.FindGameObjectsWithTag("Selection");
        for (int i = 0; i < selectionPrefabs.Length; i++)
        { 
            if (i <= 9)
            {
                selectionPrefabs[i] = selectionPrefabs[i].transform.parent.gameObject;
            }
          
            
        }

    }
}
