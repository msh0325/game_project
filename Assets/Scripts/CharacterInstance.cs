using System.Collections.Generic;
using UnityEngine;

public class CharacterInstance
{
    public string name;
    public int HP;
    public int defense;
    public int attack;
    public int speed;
    public bool isPC;

    public int positionNum;

    public testSkill1 skill;

    public CharacterInstance(CharacterStats stats, int startNum){
        name = stats.characterName;
        HP = stats.HP;
        defense = stats.defense;
        attack = stats.attack;
        speed = stats.speed;
        isPC = stats.isPC;
        positionNum = startNum;
    }

    public void takeDamage(int dmg){
        HP = HP - dmg;
    }


    public void UpdatePositionNum(int newNum){
        positionNum = newNum;
        Debug.Log($"{name}이 위치를 {newNum}번으로 바꿧어용");
    }

}
