using Bullet.Enemy;
using UnityEngine;
using System;

namespace Bullet.Manager
{
    public class EnemySpawnerController
    {
        private (Vector2 /*top-left*/, Vector2 /*bottom-right*/) enemyPositionBoundary;
        public void Init(Transform topLeft, Transform topRight)
        {
            this.enemyPositionBoundary = new (topLeft.position, topRight.position);
        }
        public void SpawnEnemies(WaveConfig spawnData, Func<Vector2, EnemyBase> enemySpawn)
        {
            int spawnQuantity = spawnData.Quantity;
            
            eEnemyAlginment EnemyAlginment = spawnData.EnemyAlginment;
            Vector2 appearanceData = spawnData.appearanceData;
            //Grid the boundary
            //Calculate for Flex
            if (appearanceData.x == 1) 
                appearanceData.x = 2;
            float column= (this.enemyPositionBoundary.Item2.x - this.enemyPositionBoundary.Item1.x) / (appearanceData.x - 1);

            if (appearanceData.y == 1) 
                appearanceData.y = 2;
            float rowStep = (this.enemyPositionBoundary.Item1.y - this.enemyPositionBoundary.Item2.y) / (appearanceData.y - 1);

            for (int i = 0; i < appearanceData.x; i++)
            {
                for (int j = 0; j < appearanceData.y; j++)
                {
                    enemySpawn.Invoke(this.enemyPositionBoundary.Item1 + Vector2.right * i * column  + Vector2.down * j * rowStep);
                }
            }

            eAppearanceMovement AppearanceType  = spawnData.AppearanceType;
            
            
            eEnemyPositioning EnemyPositioning = spawnData.EnemyPositioning;
        }
    }
}