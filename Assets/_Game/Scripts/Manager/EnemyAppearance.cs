using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.Manager
{
    /// <summary>
    /// Used for check how the enemy move before they arrived their end point
    /// </summary>
    public enum eAppearanceMovement
    {
        Unknown = -1,
        Raining = 0,
    }
    /// <summary>
    /// Used for check First enemy endpoint + spawning's sequence
    /// </summary>
    public enum eEnemyPositioning
    {
        Unknown = -1,

        LRUD = 0, LRDU = 1,
        RLUD = 2, RLDU = 3,

        UDLR = 4, UDRL = 5,
        DULR = 6, DURL = 7,
    }
    /// <summary>
    /// Used for check Step + New Boundary
    /// </summary>
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