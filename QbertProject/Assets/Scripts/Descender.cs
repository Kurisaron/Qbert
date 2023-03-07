using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Descender : MonoBehaviour
{
    protected Vector3 gravityDirection;
    protected bool canMove;

    public abstract Vector3 GravityDirection { get; set; }

    public virtual void Awake()
    {
        GravityDirection = GravityDirection;
        canMove = true;
    }
    
}
