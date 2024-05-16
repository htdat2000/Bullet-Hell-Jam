using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Event
{
    public class GameEvents : MonoBehaviour
    {
        public static Action OnWaveStart;
        public static Action OnEnemyDefeated;
    }
}