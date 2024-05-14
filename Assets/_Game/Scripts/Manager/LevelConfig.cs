using System;
using System.Collections;
using System.Collections.Generic;
using Bullet.Enemy;
using UnityEngine;

namespace Bullet.Manager
{
    //each level will have many phases.
    //In each phase will have several waves.
    [CreateAssetMenu(fileName = "New Ened Dialog Classic Data", menuName = "Game Config/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        public List<PhaseConfig> PhaseConfigs; 
        // public BossBaseBoss; 
    }

    [Serializable]
    public class PhaseConfig
    {
        public List<WaveConfig> WaveConfigs; 
    }

    [Serializable]
    public class WaveConfig
    {   //The number of enemies will be spawned and how it spawned in wave
        public EnemyBase EnemySample;
        public int Quantity;
        public eAppearanceMovement AppearanceType;
        public eEnemyPositioning EnemyPositioning;
        public eEnemyAlginment EnemyAlginment = eEnemyAlginment.Flex;
        public Vector2Int appearanceData; //Number of Column - Row 

        public bool IsHorizontalToVertical()    //whether enemies fill a row then move to next row or not
        {
            return 
                this.EnemyPositioning == eEnemyPositioning.LRUD || 
                this.EnemyPositioning == eEnemyPositioning.LRDU || 
                this.EnemyPositioning == eEnemyPositioning.RLUD || 
                this.EnemyPositioning == eEnemyPositioning.RLDU;
        } 

        public bool IsFirstAxisRevertSpawn()
        {
            return 
                this.EnemyPositioning == eEnemyPositioning.RLUD || 
                this.EnemyPositioning == eEnemyPositioning.RLDU || 
                this.EnemyPositioning == eEnemyPositioning.UDLR || 
                this.EnemyPositioning == eEnemyPositioning.UDRL;
        }

        public bool IsSecondAxisRevertSpawn()
        {
            return 
                this.EnemyPositioning == eEnemyPositioning.LRUD || 
                this.EnemyPositioning == eEnemyPositioning.RLUD || 
                this.EnemyPositioning == eEnemyPositioning.DURL || 
                this.EnemyPositioning == eEnemyPositioning.UDRL;
        }

        public Vector2 GetFirstPosition(Vector2 upleft, Vector2 downright)
        {   
            switch (this.EnemyPositioning)
            {
                case eEnemyPositioning.LRUD: //2 cases start at the up left position 
                case eEnemyPositioning.UDLR:
                    return upleft;

                case eEnemyPositioning.LRDU: //2 cases start at the down left position 
                case eEnemyPositioning.DULR:
                    return new Vector2(upleft.x, downright.y); 

                case eEnemyPositioning.RLUD: //2 cases start at the up right position 
                case eEnemyPositioning.UDRL:
                    return new Vector2(downright.x, upleft.y); 

                case eEnemyPositioning.RLDU: //2 cases start at the down right position 
                case eEnemyPositioning.DURL:
                    return downright;

                default: return Vector2.zero;
            }
        }
    }
}
