using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{

    public float health;
    public float speed;

    [Header("Set Dynamically")]
    public GameObject mouse;
    public Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        mouse = GameObject.Find("mouse");
        Vector2 dir = (transform.position - mouse.transform.position).normalized;
        rigid.velocity = dir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
