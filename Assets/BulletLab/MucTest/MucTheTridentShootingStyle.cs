using System;
using System.Collections.Generic;
using EnedUtil;
using UnityEngine;


namespace MucDemo
{
    public class MucTheTridentShootingStyle : MucTheShootingStyle
    {
        public override void Trigger(BasicBullet bulletSample, EnedPoolManager poolManager, Action onShotFinish = null)
        {
            base.Trigger(bulletSample, poolManager);
            List<Vector2> hardDirs = new();
            hardDirs.Add(Vector2.down);
            hardDirs.Add(GetRotatedVector(Vector2.down, Mathf.PI / 4));
            hardDirs.Add(GetRotatedVector(Vector2.down, Mathf.PI / -4));

            for (int i = 0; i < 3; i++)
            {
                MucTheBullet currentSample =  this.poolManager.GetObject("Simple", () => 
                {
                    IPoolable ipoolable = Instantiate(bulletSample).GetComponent<IPoolable>();
                    return ipoolable;
                }) as MucTheBullet;

                currentSample.SetActive(true);

                currentSample.SetDir(hardDirs[i]);
            }

            if (onShotFinish != null) onShotFinish?.Invoke();
        }
    }
}