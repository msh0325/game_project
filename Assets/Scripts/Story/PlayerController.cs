using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 velocity;
    private Rigidbody2D rigid;
    private float horizon;
    [SerializeField] private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        velocity = new Vector2(horizon,0);

        if(horizon > 0){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if(horizon < 0){
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(velocity.x * speed,rigid.velocity.y);
    }
}
