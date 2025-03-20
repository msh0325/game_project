using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] StoryManager storyGM;
    private Vector2 velocity;
    private Rigidbody2D rigid;
    private float horizon;
    [SerializeField] private float speed = 5.0f;
    public bool isTalking = false;
    public bool findQuest = false;
    public int questIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTalking){
            horizon = Input.GetAxisRaw("Horizontal");
            velocity = new Vector2(horizon,0);

            if(Input.GetKeyDown(KeyCode.E)&&findQuest){
                Debug.Log("Pressed E");
                storyGM.dialogPannel.SetActive(true);
                isTalking = true;
                storyGM.GetComponent<StoryManager>().StartDialog(questIndex);
            }

            if(horizon > 0){
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if(horizon < 0){
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }
        
    }

    void FixedUpdate()
    {
        if(!isTalking){
            rigid.velocity = new Vector2(velocity.x * speed,rigid.velocity.y);
        }
        else if(isTalking){
            rigid.velocity = Vector2.zero;
        }
    }
}
