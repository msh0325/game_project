using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject teleportDoor;
    private PlayerController pc;
    private Vector2 doorVec;

    void Start()
    {
        // 임시로 문 위치로 텔레포트. 맵 완성 후에는 맵 위치 지정할 예정
        doorVec = teleportDoor.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            pc = collision.gameObject.GetComponent<PlayerController>();
            pc.findDoor = true;
            pc.GetComponent<PlayerController>().teleportVec = doorVec;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            pc = collision.gameObject.GetComponent<PlayerController>();
            pc.findDoor = false;
        }
    }

}
