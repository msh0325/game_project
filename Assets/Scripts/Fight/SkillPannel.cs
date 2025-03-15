using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPannel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Button supportBtn;
    [SerializeField] Button skill1Btn;
    [SerializeField] Button skill2Btn;
    [SerializeField] Button skill3Btn;
    [SerializeField] Button defenseBtn;

    public Character selectedCharacter;
    Character testtarget;

    void Start()
    {
        supportBtn.onClick.AddListener(()=>{
            Debug.Log("Support");
            TurnGameManager.Instance.EndTurn();
        });

        skill1Btn.onClick.AddListener(()=>{
            Debug.Log("Skill1");
            selectedCharacter.useSkill(testtarget);
            TurnGameManager.Instance.EndTurn();
            
        });

        skill2Btn.onClick.AddListener(()=>{
            Debug.Log("Skill2");
            TurnGameManager.Instance.EndTurn();
        });

        skill3Btn.onClick.AddListener(()=>{
            Debug.Log("Skill3");
            TurnGameManager.Instance.EndTurn();
        });

        defenseBtn.onClick.AddListener(()=>{
            Debug.Log("Defense");
            TurnGameManager.Instance.EndTurn();
        });
    }

    public void SetCharacter(Character character,Character target){
        selectedCharacter = character;
        testtarget = target;
    }

}
