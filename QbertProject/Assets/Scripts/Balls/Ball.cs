using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : NormalDescender, INonPlayerInteractable
{
    public override void Awake()
    {
        base.Awake();

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        
    }
    
}
