using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private Animator anim;
    public bool isShow = false;
    [SerializeField] Button cancelBtn;
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
        if(Input.GetKeyDown(KeyCode.Tab)&&isShow){
            anim.SetTrigger("ClosePhone");
            transform.position = closeVec;
            isShow = false;
        }
    }
}
