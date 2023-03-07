using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDescender : Descender
{
    public override Vector3 GravityDirection
    {
        get
        {
            return gravityDirection;
        }
        set
        {
            gravityDirection = Vector3.down;
        }
    }

    public override void Awake()
    {
        base.Awake();
    }


    public void Descend(Side side)
    {
        Vector3 rayOrigin = gameObject.transform.position + (side == Side.Left ? new Vector3(1, 0, 0) : new Vector3(0, 0, 1));

        if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit))
        {
            // TO-DO: Move
            Debug.Log("Descend!");
        }
        else
        {
            Debug.Log("Cannot descend!");
        }
    }

}
