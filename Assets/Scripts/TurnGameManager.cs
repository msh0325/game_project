using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
// Linq는 쿼리 기능을 이용해 속도순으로 정렬하기 위해 사용. 오름차순/내림차순을 사용할 수 있음.
// select 이용해서 characterstats 데이터 복사.

public class TurnGameManager : MonoBehaviour
{
    public List<CharacterStats> characterStatsList;
    private List<CharacterInstance> turnOrder;
    // Start is called before the first frame update
    void Start()
    {
        //characterstats 데이터를 characterinstance로 복사
        turnOrder = characterStatsList.Select(stats => new CharacterInstance(stats)).ToList();

        //속도순으로 정렬
        turnOrder = turnOrder.OrderByDescending(character => character.speed).ToList();

        foreach(var character in turnOrder){
            Debug.Log($"name : {character.name}, speed : {character.speed}");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
