using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float TargetDistance;
    public GameObject target;
    public GameObject Weapon;
    public GameObject weaponHolstered;
    public bool attacking;
    public bool armed;
    public GameObject flank;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(target != null)
        {
            TargetDistance = Vector3.Distance(target.transform.position, transform.position);
        }

        // if (TargetDistance <= 2)

    }
    public void WeaponDraw()
    {
        armed = true;
        Weapon.SetActive(true);
        weaponHolstered.SetActive(false);
        
    }
    public void HolsterWeapon()
    {
        armed = false;
        Weapon.SetActive(false);
        weaponHolstered.SetActive(true);
        
    }
     
}
