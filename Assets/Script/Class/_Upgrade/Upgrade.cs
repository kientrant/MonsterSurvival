using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Upgrade
{
    public enum TypeUpgrade
    {
        Heart,
        Depend,
        Strength,
        Dexterity,
        Projective,
        FireCoolDown,
        SkillCollDown,
        SkillSize,
        SkillDamage,
        ExpMulti,
    }
    public string Name { get ; set; }


    public TypeUpgrade type { get; set; }


    public string Description { get; set; }

    public float upgradeValue { get; set; }

    public int CommonValue { get; set; }

    public Upgrade(string name, TypeUpgrade type, string description, float upgradeValue, int commonValue)
    {
        Name = name;
        this.type = type;
        Description = description;
        this.upgradeValue = upgradeValue;
        CommonValue = commonValue;
    }
}
