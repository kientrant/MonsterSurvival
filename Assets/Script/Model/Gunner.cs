using Assets.Script.Class;
using UnityEngine;

public class Gunner : Class
{

    public int numberProjective {  get; set; }

    public Gunner()
    {
        this.className = "LongSergeant";

        this.heathPoint = 100;

        this.defense = 1f;

        this.dexterity = 0.02f;

        this.speed = 3f;

        this.numberProjective = 1;
    }

}
