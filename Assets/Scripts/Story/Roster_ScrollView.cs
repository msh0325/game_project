using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roster_ScrollView : MonoBehaviour
{
    [SerializeField] public GameObject memberPrefab;
    [SerializeField] Button test;
    private Transform content;
    // Start is called before the first frame update
    void Start()
    {
        content = gameObject.GetComponent<Transform>();
    }

    // roster에 플레이 캐릭터가 하나씩 추가될 때, 스크롤뷰의 사이즈 늘어남
    public void AddMember(){
        Instantiate(memberPrefab,content);
    }
}
