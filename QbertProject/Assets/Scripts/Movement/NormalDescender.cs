using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDescender : Descender
{
    
    // FUNCTIONS
    public override void Awake()
    {
        base.Awake();
        gravityDirection = Vector3.down;
        leftDescendDirection = Vector3.right;
        rightDescendDirection = Vector3.forward;
    }
    
}
