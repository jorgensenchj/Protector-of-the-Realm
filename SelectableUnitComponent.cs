using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class SelectableUnitComponent : MonoBehaviour
{
    public GameObject selectionCircle;
    public UnitSelectionComponent unitSelectionComponent;
    public TroopSelector troopSelector;
    public int index;
    public bool selected;


    void Update()
    {
        if(selectionCircle == null)
        {
            selected = false;
        }else
        if (selectionCircle != null)
        {
            selected = true;
        }
    }
}

