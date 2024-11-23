using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPannel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TurnGameManager gameManager;
    [SerializeField] Button supportBtn;
    [SerializeField] Button skill1Btn;
    [SerializeField] Button skill2Btn;
    [SerializeField] Button skill3Btn;
    [SerializeField] Button defenseBtn;

    void Start()
    {
        supportBtn.onClick.AddListener(()=>{
            Debug.Log("Support");
            gameManager.EndTurn();
        });

        skill1Btn.onClick.AddListener(()=>{
            Debug.Log("Skill1");
            gameManager.EndTurn();
        });

        skill2Btn.onClick.AddListener(()=>{
            Debug.Log("Skill2");
            gameManager.EndTurn();
        });

        skill3Btn.onClick.AddListener(()=>{
            Debug.Log("Skill3");
            gameManager.EndTurn();
        });

        defenseBtn.onClick.AddListener(()=>{
            Debug.Log("Defense");
            gameManager.EndTurn();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
