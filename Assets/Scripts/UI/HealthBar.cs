using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image health;
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        health = bar.GetComponent<Image>();
        health.type = Image.Type.Filled;
        health.fillMethod = Image.FillMethod.Horizontal;
        health.fillOrigin = 0;
        //health.fillOrigin = "Left";
        //health.fillOrigin = 
        //Debug.Log(health.type);
        health.fillAmount = .7f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
