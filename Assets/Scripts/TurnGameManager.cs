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
    [SerializeField] bool isfight = false;
    [SerializeField] GameObject skillpannel;
    public List<CharacterInstance> pcTeam,enemyTeam;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        //characterstats 데이터를 characterinstance로 복사
        turnOrder = characterStatsList.Select(stats => new CharacterInstance(stats,1)).ToList();

        //속도순으로 정렬
        SetTurnOrder();

        foreach(var character in turnOrder){
            Debug.Log($"name : {character.name}, speed : {character.speed}");
        }

        StartTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SetTurnOrder(){
        turnOrder = turnOrder.OrderByDescending(character => character.speed).ToList();
    }
    
    void StartTurn(){
        if(turnOrder==null){
            Debug.Log("리스트가 비었어용");
            return;
        }
        CharacterInstance nowPlayer = turnOrder[index];
        Debug.Log($"현재 {nowPlayer.name}의 턴!");
        
        if(nowPlayer.isPC){
            //플레이어 턴 시작
            skillpannel.SetActive(true);
        }
        else{
            //적 턴 시작
            skillpannel.SetActive(false);
            EnemyTurn(nowPlayer);
        }
    }
    
    void EnemyTurn(CharacterInstance nowCharacter){
        //nowCharacter.skill.baseSkill(nowCharacter,turnOrder[0]);
        EndTurn();
    }

    public void EndTurn(){
        Debug.Log("End Turn");
        index +=1;
        /*if(turnOrder[index]!=null){
            StartTurn();
        }*/
        if(turnOrder.Count > index){
            StartTurn();
        }
        else {
            index = 0;
            SetTurnOrder();
            StartTurn();
        }
    }
}
