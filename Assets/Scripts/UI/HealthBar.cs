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
        GameObject gameManager = GameObject.Find("Game Manager");
        PlayerData playerData = gameManager.GetComponent<PlayerData>();
        playerData.onHealthChange += setHealthBar;
    }

    public void setHealthBar(int healthNum, int max)
    {
        StartCoroutine(animateHealthBar(healthNum, max));
    }

    private IEnumerator animateHealthBar(int healthNum, int max)
    {
        float startValue = health.fillAmount;
        float targetValue = (float)healthNum / max;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 4;
            health.fillAmount = Mathf.Lerp(startValue, targetValue, t);
            yield return null;
        }
    }
}
