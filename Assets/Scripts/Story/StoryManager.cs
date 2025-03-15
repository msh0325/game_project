using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

[Serializable]
    public class Dialogue{
        public string name;
        public string text;
        public string face;
    }
    
    [Serializable]
    public class DialogueData{
        public List<Dialogue> dialogues;
    }

public class StoryManager : MonoBehaviour
{
    [SerializeField] public PlayerController player;
    [SerializeField] public GameObject dialogPannel;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] Image face;
    public List<CharacterInfo> characterInfos;
    private Dictionary<string, CharacterInfo> characterDict;
    private DialogueData dialogueData;
    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 정보를 Dictionary로 저장 (빠르게 검색하기 위해)
        characterDict = new Dictionary<string, CharacterInfo>();
        foreach(var character in characterInfos){
            characterDict[character.characterName] = character;
        }

        // json 파일 불러오기
        string jsonPath = Path.Combine(Application.dataPath, "Dialogue/TestDialog.json");
        if(File.Exists(jsonPath)){
            string jsonText = File.ReadAllText(jsonPath);
            dialogueData = JsonUtility.FromJson<DialogueData>(jsonText);
        }
    }

    private void ShowDialogue(int index){
        if(dialogueData == null || index >= dialogueData.dialogues.Count) {
            return;
        }
        
        Dialogue dialogue = dialogueData.dialogues[index];
        if(characterDict.TryGetValue(dialogue.name, out CharacterInfo characterinfo)){
            Debug.Log($"{characterinfo.characterName} : {dialogue.text}");
            nameText.text = characterinfo.characterName;
            dialogText.text = dialogue.text;
        }
    }
}
