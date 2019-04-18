using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayIcon : MonoBehaviour
{
    public Image troopImageIcon;
    public Sprite troopSelected;
    public Sprite troopNotSelected;
    public int index;
    public Sprite troopIcon;
    public TroopSelector troopSelector;
  
    public GameObject troop;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // PUT THIS SHIT IN A METHOD THAT IS ONLY CALL WHEN SELLECTING!!!!
        if (troopSelector.selectionPrefabs.Length > index)
        {
            if (troopSelector.selectionPrefabs[index] != null)
            {
                troop = troopSelector.selectionPrefabs[index].gameObject;
            }
        }
        if (troopSelector.selectionPrefabs.Length <= index)
        {
            troop = null;

        }
        if (troop == null)
        {
            troopSelected = null;
            troopImageIcon.sprite = troopNotSelected;
        }
        if (troop != null)
        {
            troopSelected = troop.GetComponent<TroopData>().icon;
            troopImageIcon.sprite = troopSelected;
        }

    }

   
}
