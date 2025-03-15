using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 매니저에 캐릭 정보 넣기 (전투에 데려갈 캐릭터 정보, 전투 후 보상같은것도?)
    public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
