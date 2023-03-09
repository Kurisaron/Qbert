using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : Ball
{
    public override void Awake()
    {
        base.Awake();

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (CheckIfPlayer(other.transform) && !GameManager.Instance.enemiesFrozen)
        {
            GameManager.Instance.FreezeAllEnemies();
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
