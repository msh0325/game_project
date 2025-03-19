using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private Animator anim;
    private bool isShow = false;
    [SerializeField] Button cancelBtn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        cancelBtn.onClick.AddListener(()=>{
            if(isShow){
                Debug.Log("Close Phone");
                anim.SetTrigger("ClosePhone");
                transform.position = new Vector2(transform.position.x, -1000f);
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
            transform.position = new Vector2(gameObject.transform.position.x,0f);
            isShow = true;
        }
    }
}
