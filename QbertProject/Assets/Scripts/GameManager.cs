using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // VARIBALES ================================================
    private int currentLevel;
    private int score;

    private CubeManager cubeManager;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;

    [SerializeField]
    private GameObject warpPlatformPrefab;

    private Vector3 teleportDestination = new Vector3(0.0f, 9.0f, 0.0f);

    public bool enemiesFrozen;
    private float freezeSeconds = 5.0f;

    // UNITY FUNCTIONS ===========================================
    public override void Awake()
    {
        base.Awake();

        currentLevel = 1;
        cubeManager = gameObject.AddComponent<CubeManager>();
        SetupLevel();

        enemiesFrozen = false;
        ResetScore();
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

    private void DestroyPlayer()
    {
        Destroy(player);
    }

    // WARP PLATFORMS ==========================================

    public void SpawnWarpPlatform(Side side)
    {
        int row = Random.Range(0, 7);
        Vector3 spawnPos = new Vector3(-1.0f, 6 - row, -1.0f);
        if (side == Side.Left) spawnPos.x = row;
        if (side == Side.Right) spawnPos.z = row;

        GameObject warpPlatform = Instantiate(warpPlatformPrefab, spawnPos, Quaternion.identity);
        warpPlatform.AddComponent<WarpPlatform>();
    }

    private void DestroyWarpPlatforms()
    {
        foreach (WarpPlatform warpPlatform in FindObjectsOfType<WarpPlatform>())
        {
            Destroy(warpPlatform.gameObject);
        }
    }

    // SCORE ===================================================

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void ResetScore()
    {
        score = 0;
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

    // LEVELS ===========================================
    private void SetupLevel()
    {
        cubeManager.SetupPyramid(currentLevel);
        SpawnWarpPlatform(Side.Left);
        SpawnWarpPlatform(Side.Right);
    }

    public void CheckCubesComplete()
    {
        cubeManager.CheckCubesComplete();
    }

    public void LevelWin()
    {
        StartCoroutine(WinScreenRoutine());
    }

    private IEnumerator WinScreenRoutine()
    {
        cubeManager.DemolishPyramid();

        DestroyPlayer();

        AddScore(750 + (250 * currentLevel));
        AddScore(FindObjectsOfType<WarpPlatform>().Length * 50);

        DestroyWarpPlatforms();

        // TO-DO: Display win screen

        yield return new WaitForSeconds(2.0f);

        // TO-DO: Clear win screen

        currentLevel += 1;
        SetupLevel();
        SpawnPlayer();
    }
}
