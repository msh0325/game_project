using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSkill : ScriptableObject
{

    public string skillname;
    public string range;
    
    public virtual void baseSkill(CharacterInstance user, CharacterInstance target){
        Debug.Log($"{user.name}이 {skillname}으로 {target.name}을 공격");
    }

}
