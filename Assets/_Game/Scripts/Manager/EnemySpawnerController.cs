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
        public void SpawnEnemies(WaveConfig spawnData, Func<EnemyBase> enemySpawn, Action callback = null)
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

            // StartCoroutine(SpawnEnemiesCor(appearanceData.x, appearanceData.y, enemySpawn, spawnQuantity));
            StartCoroutine(SpawnEnemiesCor(spawnData, enemySpawn, callback));
        }

        private IEnumerator SpawnEnemiesCor(WaveConfig spawnData, Func<EnemyBase> enemySpawn, Action callback = null)
        {
            //Non center
            int column = spawnData.appearanceData.x;
            int row = spawnData.appearanceData.y;

            Vector2 topleft = this.enemyPositionBoundary.Item1;
            Vector2 downright = this.enemyPositionBoundary.Item2;

            if (column <= 1)
            {   //Get the middle column by dividing sum of x value of left and right 
                float middleColum = (topleft.x + downright.x) / 2;
                topleft.x = middleColum;
                downright.x = middleColum;
            }
            if (row <= 1)
            {   //The middle row is the middle of the box 
                //Get it by dividing the length of the cross (sum of top left and bottom right )
                float middleRow = (topleft.y + downright.y) / 2;
                topleft.y = middleRow;
                downright.y = middleRow;
            }

            float columnStep = (downright.x - topleft.x) / (column >= 1 ? column - 1 : 1);
            float rowStep = (topleft.y - downright.y) / (row >= 1 ? row - 1 : 1);
            int count = 0;

            Vector2 firstPoint = spawnData.GetFirstPosition(topleft, downright);
            
            //DULR
            int firstLoop = spawnData.IsHorizontalToVertical() ? column : row  ; 
            int secondLoop = spawnData.IsHorizontalToVertical() ? row : column  ;
            bool is1stRevert = spawnData.IsFirstAxisRevertSpawn();
            bool is2ndRevert = spawnData.IsSecondAxisRevertSpawn();

            bool isHorizontalToVertical = spawnData.IsHorizontalToVertical();
            if (isHorizontalToVertical)
            {
                firstLoop = row; secondLoop = column;
            }
            else
            {
                firstLoop = column; secondLoop = row;
            }

            for (int i = 0; i < firstLoop; i++)
            {
                if (count == spawnData.Quantity) 
                        break;
                for (int j = 0; j < secondLoop; j++)
                {
                    if (count == spawnData.Quantity) 
                        break;

                    int columnIndex = 0;
                    int rowIndex = 0;
                    if (isHorizontalToVertical)
                    {
                        columnIndex = j; rowIndex = i;
                        if (is1stRevert)
                            columnIndex *= -1;
                        if (is2ndRevert)
                            rowIndex *= -1;
                    }
                    else
                    {
                        columnIndex = i; rowIndex = j;
                        if (is1stRevert)
                            rowIndex *= -1;
                        if (is2ndRevert)
                            columnIndex *= -1;
                    }

                    Vector2 endPoint = firstPoint + Vector2.right * columnIndex * columnStep + Vector2.up * rowIndex * rowStep;



                    EnemyBase newEnemy = enemySpawn.Invoke();
                    newEnemy.SetEndPoint(endPoint);
                    newEnemy.MoveSpawn(spawnData.AppearanceType); //Affected by eAppearanceMovement



                    count ++;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            callback?.Invoke();
        }
    }
}