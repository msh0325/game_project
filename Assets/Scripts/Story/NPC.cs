using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private StoryManager storyGM;
    [SerializeField] public TextAsset[] quest;
    private PlayerController pc;
    public int questNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        pc = storyGM.GetComponent<StoryManager>().player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // questNum 이 quest의 갯수과 같다면(즉, 퀘스트를 모두 수행했다면) Collider를 비활성화
        if(questNum == quest.Length){
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Debug.Log("Player");
            storyGM.nowNPC = gameObject;
            pc.questIndex = questNum;
            pc.findQuest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Debug.Log("out");
            storyGM.nowNPC = null;
            pc.findQuest = false;
        }        
    }
}
