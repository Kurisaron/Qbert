using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : Ball
{
    public override void Awake()
    {
        base.Awake();

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (CheckIfPlayer(other.transform))
        {
            GameManager.Instance.KillPlayer();
        }
    }

    private bool CheckIfPlayer(Transform t)
    {
        if (t.parent != null)
        {
            return CheckIfPlayer(t.parent);
        }
        
        return t.gameObject.name == "Qbert";
    }
}
