using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Cheese : MonoBehaviour
{

    public float health;
    public float speed;
    public float animationVelocity;
    public float animationHeight;
    public float animationRotation;
    public Action onDeath;
    public GameObject animatedCheese;
    public Rigidbody2D rigid2D;
    public SpriteRenderer spriteRenderer;

    [Header("Set Dynamically")]
    public GameObject mouse;
    
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.Find("mouse");
        Vector2 dir = (mouse.transform.position - transform.position).normalized;
        rigid2D.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Scream")
        {
            StartCoroutine(deathAnimation());
        }
    }

    private IEnumerator deathAnimation()
    {
        GameObject go = Instantiate(animatedCheese, transform.position, transform.rotation);
        Rigidbody rigid = go.GetComponent<Rigidbody>();
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();

        go.transform.localScale = transform.localScale;
        rigid.velocity = (Vector3)(-rigid2D.velocity * animationVelocity) + Vector3.forward * animationHeight;
        rigid.angularVelocity = Random.insideUnitCircle.normalized * animationRotation;
        sr.sprite = spriteRenderer.sprite;

        rigid2D.simulated = false;
        spriteRenderer.enabled = false;
        
        yield return new WaitForSeconds(3);
        Destroy(go);
        onDeath.Invoke();
        Destroy(gameObject);
    }
}
