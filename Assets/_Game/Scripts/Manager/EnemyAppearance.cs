using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Manager
{
    public enum eAppearanceMovement
    {
        Unknown = -1,
        Raining = 0,
    }
    public enum eEnemyPositioning
    {
        Unknown = -1,
        LRUP = 0, LRDU = 1,
        RLUD = 2, RLDU = 3,
        UDLR = 4, UDRL = 5,
        DULR = 6, DURL = 7,
    }
    public enum eEnemyAlginment
    {
        Unknown = -1,
        Flex = 0,
        Close = 1,
        Left = 2, Right = 3, Up = 2, Down = 3,
    }

    public class EnemyAppearance
    {
        public eAppearanceMovement type;
    }
}