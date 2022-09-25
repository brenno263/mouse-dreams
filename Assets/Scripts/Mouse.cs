using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mouse : MonoBehaviour
{

    public float baseRotationSpeed;
    public float baseFireRate;
    public float baseProjectileSpeed;
    public float baseProjectileRange;
    public float baseProjectileWidth;
    public int baseDamage;
    public int baseProfit;

    public GameObject screamObject;
    public GameObject gameManager;
    public PlayerData playerData;

    public List<AudioClip> screams;
    public AudioSource audioSource;

    private float _lastProjectileTime;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Cheese")
        {
            playerData.Health--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - (Vector2)transform.position;
        float rotateAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, rotateAngle - 90));
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, targetRotation, baseRotationSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            tryScream();
        }
    }

    void tryScream()
    {
        float timeElapsed = Time.time - _lastProjectileTime;
        float cooldownTime = 1 / (baseFireRate + playerData.getUpgradeLevel(UpgradeType.FireRate) * 0.5f);
        if (timeElapsed < cooldownTime) return;
        _lastProjectileTime = Time.time;
        
        screamSound();
        
        GameObject screamGo = Instantiate(screamObject, transform.position, transform.rotation);
        Scream scream = screamGo.GetComponent<Scream>();
        Rigidbody2D sRigid = screamGo.GetComponent<Rigidbody2D>();
        Transform sTrans = screamGo.transform;

        sRigid.velocity = sTrans.up * baseProjectileSpeed;
        Vector3 scale = sTrans.localScale;
        scale.x = scale.x * (1 + playerData.getUpgradeLevel(UpgradeType.Width) * 0.2f);
        sTrans.localScale = scale;

        scream.maxDistance = baseProjectileRange + playerData.getUpgradeLevel(UpgradeType.Range) * 2;
        scream.onHit = () =>
        {
            int profit = baseProfit + (int)playerData.getUpgradeLevel(UpgradeType.Profit) * 10;
            playerData.Money += profit;
        };
    }

    void screamSound()
    {
        AudioClip scream = screams[Random.Range(0, screams.Count)];
        audioSource.clip = scream;
        audioSource.Play();
    }
}
