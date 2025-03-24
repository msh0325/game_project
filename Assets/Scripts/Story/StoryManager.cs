using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using UnityEngine.UI;

[Serializable]
    public class Dialogue{
        public string name;
        public string text;
        public string face;
        public string imgSpace;
    }
    
    [Serializable]
    public class DialogueData{
        public List<Dialogue> dialogues;
    }

public class StoryManager : MonoBehaviour
{
    [SerializeField] public PlayerController player;
    [SerializeField] public GameObject dialogPannel;
    [SerializeField] public GameObject[] Map;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] Button nextBtn;
    [SerializeField] Image pcface;
    [SerializeField] Image npcface;
    public List<CharacterInfo> characterInfos;
    public GameObject nowNPC = null;
    private int nowquestNum = 0;
    private int dialogIndex = 0;
    private Dictionary<string, CharacterInfo> characterDict;
    private DialogueData dialogueData;
    private Color talkColor = Color.white;
    private Color nontalkColor = new Color(0.1f,0.1f,0.1f);
    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 정보를 Dictionary로 저장 (빠르게 검색하기 위해)
        characterDict = new Dictionary<string, CharacterInfo>();
        foreach(var character in characterInfos){
            characterDict[character.characterName] = character;
        }

        // 화면 누르면 다음 대사 보이기
        nextBtn.onClick.AddListener(()=>{
            Debug.Log("click");
            if(dialogPannel.activeSelf){  
                dialogIndex += 1;
                ShowDialogue(nowquestNum,dialogIndex);
            }
        });
    }

    public void StartDialog(int questNum){
        nowquestNum = questNum;
        ShowDialogue(questNum,dialogIndex);
    }

    // json 파일에서 대사 출력하는 함수
    private void ShowDialogue(int questNum,int index){

        // 현재 접하고 있는 npc의 quest를 확인
        if(nowNPC.GetComponent<NPC>().quest[questNum] != null){
            TextAsset questText = nowNPC.GetComponent<NPC>().quest[questNum];
            string jsonText = questText.text;
            dialogueData = JsonUtility.FromJson<DialogueData>(jsonText);
        }

        // dialogueData가 비었거나, 대화가 끝까지 진행되었다면 실행
        if(dialogueData == null || index >= dialogueData.dialogues.Count) {
            Debug.Log("대화 끗");
            dialogPannel.SetActive(false);
            player.isTalking = false;
            dialogIndex = 0;
            nowNPC.GetComponent<NPC>().questNum +=1;
            return;
        }
        
        Dialogue dialogue = dialogueData.dialogues[index];
        if(characterDict.TryGetValue(dialogue.name, out CharacterInfo characterinfo)){
            nameText.text = characterinfo.characterName;
            dialogText.text = dialogue.text;
            SelectFaceSprite(dialogue,characterinfo);
        }
    }

    private void SelectFaceSprite(Dialogue dialogue, CharacterInfo characterinfo){
        int facenum = 0;
        switch(dialogue.face){
            case "normal" : 
                facenum = 0;
                break;
            
            case "talk" :
                facenum = 1;
                break;
        }

        switch(dialogue.imgSpace){
            case "left" :
                pcface.enabled = true;
                pcface.color = talkColor;
                if(npcface.enabled == true){
                    npcface.color = nontalkColor;
                }
                pcface.sprite = characterinfo.faces[facenum];
                break;
            
            case "right" :
                npcface.enabled = true;
                npcface.color = talkColor;
                if(pcface.enabled == true){
                    pcface.color = nontalkColor;
                }
                npcface.sprite = characterinfo.faces[facenum];
                break;
        }
    }
}
