//ScriptableObject를 활용해 캐릭터의 초기 데이터 정의하기.
using System.Collections.Generic;
using UnityEngine;

// asset 메뉴에 turnRPG/CharacterStats 위치에 CharacterStats 저장.
[CreateAssetMenu(fileName = "CharacterStats", menuName = "turnRPG/CharacterStats")]

public class CharacterStats : ScriptableObject
{
    public string characterName;
    public int HP;
    public int defense;
    public int attack;
    public int speed;
    public bool isPC;

    

}