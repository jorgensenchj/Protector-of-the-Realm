using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName ="New Card",menuName ="CharacterData")]

public class CharacterData : ScriptableObject {

    public new string name;
    public string discription;
    public int health;
    public int skill;
    public int armor;
    public int Strength;
    
    public Sprite art;


}
