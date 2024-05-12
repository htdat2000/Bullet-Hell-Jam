using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Bullet.Manager;
using Unity.Mathematics;

public class WaveSample : MonoBehaviour
{
    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform botRight;
    [SerializeField] private EnemySpawnerController enemySpawnerController;
    [SerializeField] private Transform enemiesContainer;
    public WaveConfig waveConfig;

    private void Start()
    {
        enemySpawnerController.Init(topLeft, botRight);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            enemySpawnerController.SpawnEnemies(waveConfig, () => {
                return Instantiate(waveConfig.EnemySample, this.enemiesContainer);
            }, null);
        }
    }
}