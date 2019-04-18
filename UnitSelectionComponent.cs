using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class UnitSelectionComponent : MonoBehaviour
{
    bool isSelecting = false;
    Vector3 mousePosition1;
    public List<GameObject> selectedtroops = new List<GameObject>();
    public GameObject selectionCirclePrefab;
    public TroopSelector troopSelector;
    
    void Start()
    {
   
    }
  
    void Update()
    {
       

        // If we press the left mouse button, begin selection and remember the location of the mouse
        if ( Input.GetMouseButtonDown( 0 ) )
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;

            foreach( var selectableObject in FindObjectsOfType<SelectableUnitComponent>())
            {
                if( selectableObject.selectionCircle != null )
                {
                    //Destorys prefab but no prefab error message;
                    
                    Destroy( selectableObject.selectionCircle.gameObject );
                    
                    selectableObject.selectionCircle = null;
                }
            }
        }
   
            // If we let go of the left mouse button, end selection
            if ( Input.GetMouseButtonUp( 0 ) )
        {
            SelectionFull();


        }

        // Highlight all objects within the selection box
        if( isSelecting )
        {
            if(troopSelector.selectionPrefabs.Length <= 9)
            {
                AddSelectionCircle();
            }
            


        }
    }

    public bool IsWithinSelectionBounds( GameObject gameObject )
    {
        if( !isSelecting )
            return false;

        var camera = Camera.main;
        var viewportBounds = Utils.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
        return viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ) );
    }
    public void SelectionFull()
    {
        var selectedObjects = new List<SelectableUnitComponent>();

        foreach (var selectableObject in FindObjectsOfType<SelectableUnitComponent>())
        {

            if (IsWithinSelectionBounds(selectableObject.gameObject))
            {

                selectedObjects.Add(selectableObject);

            }



        }


        var sb = new StringBuilder();
        sb.AppendLine(string.Format("Selecting [{0}] Units", selectedObjects.Count));
        foreach (var selectedObject in selectedObjects)
            sb.AppendLine("-> " + selectedObject.gameObject.name);
        Debug.Log(sb.ToString());

        isSelecting = false;
    }
    public void AddSelectionCircle()
    {
        foreach (var selectableObject in FindObjectsOfType<SelectableUnitComponent>())
        {

            if (IsWithinSelectionBounds(selectableObject.gameObject))
            {
                if (selectableObject.selectionCircle == null)
                {
                    if (selectedtroops.Count <= 9)
                    {
                        selectedtroops.Add(selectableObject.gameObject);
                    }
                        selectableObject.selectionCircle = Instantiate(selectionCirclePrefab);
                    selectableObject.selectionCircle.transform.SetParent(selectableObject.transform, false);
                    selectableObject.selectionCircle.transform.eulerAngles = new Vector3(90, 0, 0);
                }

            }

            else
            {
                if (selectableObject.selectionCircle != null)
                {
                    selectedtroops.Remove(selectableObject.gameObject);
                    Destroy(selectableObject.selectionCircle.gameObject);
                    selectableObject.selectionCircle = null;


                }
            }

        }

    }
    void OnGUI()
    {
        if( isSelecting )
        {
            // Create a rect from both mouse positions
            var rect = Utils.GetScreenRect( mousePosition1, Input.mousePosition );
            Utils.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
            Utils.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
        }
    }
}