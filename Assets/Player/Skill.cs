using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum SkillType
    {
        Dash
    }
    public class Skill
    {
        public virtual void Trigger(GameObject character, Vector2 moveDir) { }
    }
}