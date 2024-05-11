using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Bullet.Manager;

public class WaveSample : MonoBehaviour
{
    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform botRight;
    public WaveConfig waveConfig;
    private EnemySpawnerController enemySpawnerController = new();

    private void Start()
    {
        enemySpawnerController.Init(topLeft, botRight);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            enemySpawnerController.SpawnEnemies(waveConfig, (position) => {
                return Instantiate(waveConfig.EnemySample, position, Quaternion.identity);
            });
        }
    }
}