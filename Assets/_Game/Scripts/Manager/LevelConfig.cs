using System;
using System.Collections;
using System.Collections.Generic;
using Bullet.Enemy;
using UnityEngine;

namespace Bullet.Manager
{

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
    {
        public EnemyBase EnemySample;
        public int Quantity;
        public eAppearanceMovement AppearanceType;
        public eEnemyPositioning EnemyPositioning;
        public eEnemyAlginment EnemyAlginment = eEnemyAlginment.Flex;
        public Vector2 appearanceData; //Column - Row
    }
}
