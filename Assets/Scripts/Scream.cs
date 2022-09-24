using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public float shotSpeed;
    public float maxDistance;
    public Action onHit;

    private Rigidbody2D _rigid;
    private Vector2 _startPos;
    private Vector3 _startScale;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _startScale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(onHit != null)
            onHit.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTraveled = ((Vector2)transform.position - _startPos).magnitude;
        transform.localScale = _startScale * distanceTraveled;

        if (distanceTraveled > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
