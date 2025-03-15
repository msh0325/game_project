using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCharacterInfo", menuName ="turnRPG/CharacterInfo")]

public class CharacterInfo : ScriptableObject
{
    [SerializeField] public Sprite[] faces;
    [SerializeField] public string characterName;
    [SerializeField] public bool nowTalking;
}
