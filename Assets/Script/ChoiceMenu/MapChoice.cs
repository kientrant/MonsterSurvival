using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChoice : MonoBehaviour
{
    public int index;
    public ValueTranser transer;
    
    public void MapSelect()
    {
        transer.MapName = index;
    }
}
