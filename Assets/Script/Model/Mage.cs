using Assets.Script.Class;
using UnityEngine;

public class Mage : Class
{

    public float sizeOfSpell {  get; set; }

    public Mage()
    {
        this.className = "HaiMage";

        this.heathPoint = 80;

        this.defense = 1.1f;

        this.dexterity = 0.3f;

        this.speed = 3f;

        this.sizeOfSpell = 1;
    }

}
