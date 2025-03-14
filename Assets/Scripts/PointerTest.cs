using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerTest : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Character character;

    [SerializeField] GameObject skillPannel;
    [SerializeField] Material outline;
    [SerializeField] Material material;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("클릭됐어용");
    }

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("올라왔지롱");
    }
    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("내려왔지롱");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
