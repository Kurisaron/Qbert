using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NormalDescender : Descender
{
    public override Vector3 GravityDirection
    {
        get
        {
            return Vector3.down;
        }
    }

    public abstract void Descend(Side side);
}
