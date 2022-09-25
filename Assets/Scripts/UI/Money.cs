using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Money : MonoBehaviour
{
    public float animTime;
    public TMPro.TextMeshProUGUI text;

    private Coroutine animation;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        GameObject gameManager = GameObject.Find("Game Manager");
        PlayerData playerData = gameManager.GetComponent<PlayerData>();
        playerData.onMoneyChange += setMoney;
        playerData.Money = playerData.Money;
    }

    public void setMoney(int startMoney, int newMoney)
    {
         
        if(animation != null)
            StopCoroutine(animation);
        animation = StartCoroutine(animateSetMoney(startMoney, newMoney));
    }

    private IEnumerator animateSetMoney(int startMoney, int newMoney)
    {
        float t = 0;
        while (t < animTime)
        {
            t += Time.deltaTime;
            text.text = "$" + (int)Mathf.Lerp(startMoney, newMoney, t / animTime);
            yield return null;
        }
    }
}
