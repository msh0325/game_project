using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newSkill", menuName = "turnRPG/Skill")]
public class testSkill1 : CharacterSkill
{

    public int dmg;

    public override void baseSkill(Character user, Character target)
    {
        Debug.Log($"{user.name}이 {target.name}에게 공격!");
        base.baseSkill(user, target);
        target.takeDamage(dmg);
    }
}
