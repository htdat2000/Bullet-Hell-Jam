using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event;

namespace Bullet.Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform topLeft;
        [SerializeField] private Transform botRight;
        [SerializeField] private EnemySpawnerController enemySpawnerController;
        [SerializeField] private Transform enemiesContainer;

        [SerializeField] protected LevelConfig levelOneConfig;

        protected bool isPhaseEnd = false;
        protected bool isWaveEnd = false;

        protected int enemyQuantity;
        protected int enemyDefeated;

        protected void Start()
        {
            GameEvents.OnEnemyDefeated += OnEnemyDefeated;
        }
        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(ReadLevel(levelOneConfig));
                //Event.GameEvents.OnWaveStart?.Invoke();
                Debug.Log("Press T");
            }
        }
        protected void OnDisable()
        {
            GameEvents.OnEnemyDefeated -= OnEnemyDefeated;
        }
        IEnumerator ReadLevel(LevelConfig level)    //Reading phases in a level
        {
            Debug.Log("Read Level");
            Debug.Log(level.PhaseConfigs.Count);
            for (int i = 0; i <= level.PhaseConfigs.Count - 1; i++)
            {
                Debug.Log("First Phase");
                isPhaseEnd = false;
                StartCoroutine(ReadPhase(level.PhaseConfigs[i]));
                yield return new WaitUntil(() => isPhaseEnd == true);
            }
        }
        IEnumerator ReadPhase(PhaseConfig phase)    //Reading waves in a phase
        {
            for (int i = 0; i <= phase.WaveConfigs.Count - 1; i++)
            {
                Debug.Log("First wave");
                ReadWave(phase.WaveConfigs[i]);
                yield return new WaitUntil(() => isWaveEnd == true);
            }
            isPhaseEnd = true;
        }
        protected void ReadWave(WaveConfig wave)
        {
            isWaveEnd = false;
            enemyQuantity = wave.Quantity;
            enemyDefeated = 0;
            enemySpawnerController.SpawnEnemies(wave, () =>
            {
                return Instantiate(wave.EnemySample, this.enemiesContainer);
            }, () => Event.GameEvents.OnWaveStart?.Invoke());
        }
        protected void OnEnemyDefeated()
        {
            enemyDefeated++;
            if (enemyDefeated == enemyQuantity)
            {
                isWaveEnd = true;
            }
        }
    }
}