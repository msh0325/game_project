using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newSkill", menuName = "turnRPG/Skill")]
public class testSkill1 : CharacterSkill
{

    int dmg;

    public override void baseSkill(CharacterInstance user, CharacterInstance target)
    {
        base.baseSkill(user, target);
        target.takeDamage(dmg);
    }
}
