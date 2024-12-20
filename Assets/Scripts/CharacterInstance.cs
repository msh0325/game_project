using UnityEngine;

public class CharacterInstance
{
    public string name;
    public int HP;
    public int defense;
    public int attack;
    public int speed;
    public bool isPC;

    public CharacterInstance(CharacterStats stats){
        name = stats.characterName;
        HP = stats.HP;
        defense = stats.defense;
        attack = stats.attack;
        speed = stats.speed;
        isPC = stats.isPC;
    }
}
