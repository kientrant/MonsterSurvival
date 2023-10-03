using Assets.Script.Class;
using UnityEngine;

public class Warrior : Class
{

    public float sizeOfSpell {  get; set; }

    public Warrior()
    {
        this.className = "HaiMage";

        this.heathPoint = 200;

        this.defense = 0.9f;

        this.dexterity = 0.01f;

        this.speed = 3f;

        this.sizeOfSpell = 1;
    }

}
