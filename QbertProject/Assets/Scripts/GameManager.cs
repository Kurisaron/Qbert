using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // VARIBALES ================================================
    private CubeSpawner cubeSpawner;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;

    private Vector3 teleportDestination = new Vector3(1.0f, 9.0f, 0.0f);

    public bool enemiesFrozen;
    private float freezeSeconds = 5.0f;

    // UNITY FUNCTIONS ===========================================
    public override void Awake()
    {
        base.Awake();

        cubeSpawner = gameObject.AddComponent<CubeSpawner>();
        cubeSpawner.SetupPyramid(1);
        enemiesFrozen = false;
    }

    private void Start()
    {
        SpawnPlayer();
    }

    // PLAYER ====================================================
    private void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, teleportDestination, Quaternion.identity);
        PlayerController.Instance.playerLocomotion = player.AddComponent<PlayerLocomotion>();
        
    }

    public void TeleportPlayer()
    {
        player.transform.position = teleportDestination;
    }

    public void KillPlayer()
    {

    }

    // FREEZE ==================================================
    public void FreezeAllEnemies()
    {
        enemiesFrozen = true;
        StartCoroutine(FreezeRoutine());
    }

    private IEnumerator FreezeRoutine()
    {
        // TO-DO: Freeze all enemies
        
        yield return new WaitForSeconds(freezeSeconds);

        // TO-DO: Unfreeze all enemies
        enemiesFrozen = false;
    }
}
