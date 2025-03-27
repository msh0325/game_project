using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private Animator anim;
    public bool isShow = false;
    [SerializeField] Button cancelBtn;
    [SerializeField] Button RosterBtn;
    [SerializeField] Button StageBtn;
    [SerializeField] Button QuestBtn;
    [SerializeField] Button OptionBtn;
    [SerializeField] GameObject roster;
    [SerializeField] GameObject stage;
    private Vector2 showVec = new Vector2(470,0f);
    private Vector2 closeVec = new Vector2(470,-1000f);

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // cancle 버튼을 누르면 Phone UI 꺼짐
        cancelBtn.onClick.AddListener(()=>{
            if(isShow){
                Debug.Log("Close Phone");
                anim.SetTrigger("ClosePhone");
                transform.position = closeVec;
                isShow = false;
            }
        });

        // roster 버튼을 눌러서 멤버 편성창 전환 (Phone이 켜져있을때만)
        RosterBtn.onClick.AddListener(()=>{
            Debug.Log("Roster");
            roster.SetActive(true);
            roster.GetComponent<Animator>().Play("ShowUI_Anim");
        });

        // stage 버튼을 눌러서 스테이지 선택창 전환 (퀘스트를 받았으면 갈 수 있음?)
        StageBtn.onClick.AddListener(()=>{
            Debug.Log("Stage");
            stage.SetActive(true);
            stage.GetComponent<Animator>().Play("ShowUI_Anim");
        });
    }

    // Update is called once per frame
    void Update()
    {
        // tab키를 누를 시 Phone UI 등장
        if(Input.GetKeyDown(KeyCode.Tab)&&!isShow){
            Debug.Log("Open Phone");
            anim.SetTrigger("ShowPhone");
            transform.position = showVec;
            isShow = true;
        }
        // Phone UI가 있을 때 tab 키를 누르면 UI 꺼짐
        else if(Input.GetKeyDown(KeyCode.Tab)&&isShow){
            Debug.Log("Close Phone");
            anim.SetTrigger("ClosePhone");
            transform.position = closeVec;
            isShow = false;
        }
        // ESC를 누르면 휴대폰으로 킨 UI없어짐(ex 편성창)
        if(Input.GetKeyDown(KeyCode.Escape)){
            roster.SetActive(false);
            stage.SetActive(false);
        }
    }
}
