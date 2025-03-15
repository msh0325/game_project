using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private StoryManager storyGM;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = storyGM.GetComponent<StoryManager>().player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Debug.Log("Player");
            pc.findQuest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Debug.Log("out");
            pc.findQuest = false;
        }        
    }
}
