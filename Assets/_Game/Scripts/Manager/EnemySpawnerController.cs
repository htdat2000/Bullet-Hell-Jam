using Bullet.Enemy;
using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

namespace Bullet.Manager
{
    public class EnemySpawnerController : MonoBehaviour
    {
        private (Vector2 /*top-left*/, Vector2 /*bottom-right*/) enemyPositionBoundary;
        public void Init(Transform topLeft, Transform topRight)
        {
            this.enemyPositionBoundary = new (topLeft.position, topRight.position);
        }
        public void SpawnEnemies(WaveConfig spawnData, Func<Vector2, EnemyBase> enemySpawn)
        {
            int spawnQuantity = spawnData.Quantity;
            
            Vector2Int appearanceData = spawnData.appearanceData;
            //Grid the boundary
            //Calculate for Flex
            if (appearanceData.x == 1) 
                appearanceData.x = 2;
            if (appearanceData.y == 1) 
                appearanceData.y = 2;


            eEnemyAlginment EnemyAlginment = spawnData.EnemyAlginment;
            eAppearanceMovement AppearanceType  = spawnData.AppearanceType;            
            eEnemyPositioning EnemyPositioning = spawnData.EnemyPositioning;

            StartCoroutine(SpawnEnemiesCor(appearanceData.x, appearanceData.y, enemySpawn, spawnQuantity));
        }

        //DULR - Flex
        private IEnumerator SpawnEnemiesCor(int column, int row, Func<Vector2, EnemyBase> enemySpawn, int maxSpawn, Action callback = null)
        {
            float columnStep= (this.enemyPositionBoundary.Item2.x - this.enemyPositionBoundary.Item1.x) / (column - 1); //Affected by eEnemyAlginment
            float rowStep = (this.enemyPositionBoundary.Item1.y - this.enemyPositionBoundary.Item2.y) / (row - 1); //Affected by eEnemyAlginment
            int count = 0;

            Vector2 firstPoint = new Vector2(this.enemyPositionBoundary.Item1.x, this.enemyPositionBoundary.Item2.y); //Affected by eEnemyPositioning
            for (int i = 0; i < column; i++) //Affected by eEnemyPositioning
            {
                if (count == maxSpawn) 
                        break;
                for (int j = 0; j < row; j++) //Affected by eEnemyPositioning
                {
                    if (count == maxSpawn) 
                        break;
                    Vector2 endPoint = firstPoint + Vector2.right * i * columnStep  + Vector2.up * j * rowStep;
                    Vector2 startPoint = endPoint + Vector2.up * 10f; //Affected by eAppearanceMovement
                    EnemyBase newEnemy = enemySpawn.Invoke(startPoint);
                    newEnemy.SetEndPoint(endPoint);
                    newEnemy.Move(); //Affected by eAppearanceMovement
                    count ++;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            callback?.Invoke();
        }
    }
}