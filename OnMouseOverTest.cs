using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverTest : MonoBehaviour
{
    public CharacterData card;
    public CardData cardData;

    private void Start()
    {
        card = GetComponentInParent<EnemyDamage>().card;
    }
    void OnMouseOver()
    {
        cardData.card = card;
        cardData.changeCard();
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
