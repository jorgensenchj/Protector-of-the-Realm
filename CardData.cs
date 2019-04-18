using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour {

    CharacterData characterData;

    public CharacterData card;
    public Image ArtworkImage;
    public Text nameText;
    public Text discriptionText;
    public Text healthText;
    public Text skillText;
    public Text armorText;
    public Text StrengthText;


    private void Start()
    {
        ArtworkImage.sprite = card.art;
        nameText.text = card.name;
        discriptionText.text = card.discription;
        healthText.text = card.health.ToString();
        skillText.text = card.skill.ToString();
        armorText.text = card.armor.ToString();
        StrengthText.text = card.Strength.ToString();
    }
    public void changeCard()
    {
        ArtworkImage.sprite = card.art;
        nameText.text = card.name;
        discriptionText.text = card.discription;
        healthText.text = card.health.ToString();
        skillText.text = card.skill.ToString();
        armorText.text = card.armor.ToString();
        StrengthText.text = card.Strength.ToString();
    }
}
