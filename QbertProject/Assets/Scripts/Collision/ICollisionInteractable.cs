using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionInteractable
{
    // FUNCTIONS
    void OnTriggerEnter(Collider other);
}
