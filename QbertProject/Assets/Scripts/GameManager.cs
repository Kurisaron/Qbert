using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private CubeSpawner cubeSpawner;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;

    private Vector3 teleportDestination = new Vector3(1.0f, 9.0f, 0.0f);

    public override void Awake()
    {
        base.Awake();

        cubeSpawner = gameObject.AddComponent<CubeSpawner>();
        cubeSpawner.SetupPyramid(1);
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, teleportDestination, Quaternion.identity);
        PlayerController.Instance.playerLocomotion = player.AddComponent<PlayerLocomotion>();
        
    }

    public void TeleportPlayer()
    {
        player.transform.position = teleportDestination;
    }
}
