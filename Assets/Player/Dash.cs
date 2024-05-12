using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    protected float dashSpeed = 2;

    public override void Trigger(GameObject character, Vector2 moveDir)
    {
        Dash(character, moveDir);
    }
    protected void Dash(GameObject character, Vector2 moveDir)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dash");
            character.transform.Translate(dashSpeed * moveDir.normalized);
        }
    }
}
