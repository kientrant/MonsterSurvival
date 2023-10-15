using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "ValueTranser", menuName = "My Game/ValueTranser")]
public  class ValueTranser : ScriptableObject
    {
        public int ClassPlayer = 0;

        public int MapName = 0;

    public override string ToString()
    {
        return ClassPlayer + "," + MapName;
    }
}
