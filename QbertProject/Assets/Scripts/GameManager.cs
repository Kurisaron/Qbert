using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private CubeSpawner cubeSpawner;

    public override void Awake()
    {
        base.Awake();

        cubeSpawner = gameObject.AddComponent<CubeSpawner>();
        cubeSpawner.SetupPyramid(1);
    }
}
