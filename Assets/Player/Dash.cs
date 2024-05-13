using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public class DashSkill : Skill
    {
        protected float dashAmount = 5f;
        protected float dashSpeed = 0.5f;

        public override void Trigger(GameObject character, Vector2 moveDir)
        {
            Dash(character, moveDir);
        }
        protected void Dash(GameObject character, Vector2 moveDir)
        {
            Vector3 startPos = character.transform.position;
            Vector3 endPos =  new Vector3 (startPos.x + moveDir.x * dashAmount, startPos.y + moveDir.y * dashAmount, 0);
            character.transform.DOMove(endPos, dashSpeed);
        }
    }
}