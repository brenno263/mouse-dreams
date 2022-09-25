using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    public float waveTextTime;
    public float waveTextLingerTime;
    public float waveTextBottomPos;
    
    RectTransform waveTextTrans;
    private TextMeshProUGUI waveTextText;
    public CheeseSpawner spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Game Manager").GetComponent<CheeseSpawner>();
        waveTextTrans = GetComponent<RectTransform>();
        waveTextText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(showWaveText());
    }

    private IEnumerator showWaveText()
    {
        yield return new WaitForEndOfFrame();
        waveTextText.text = "Wave " + spawner.currentWave;
        Vector2 startPos = waveTextTrans.anchoredPosition;
        Vector2 bottomPos = startPos;
        bottomPos.y = waveTextBottomPos;
        float t = 0;
        while (t < waveTextTime)
        {
            t += Time.deltaTime;
            waveTextTrans.anchoredPosition = Vector2.Lerp(startPos, bottomPos, t / waveTextTime);
            yield return null;
        }

        yield return new WaitForSeconds(waveTextLingerTime);

        t = 0;
        while (t < waveTextTime)
        {
            t += Time.deltaTime;
            waveTextTrans.anchoredPosition = Vector2.Lerp(bottomPos, startPos, t / waveTextTime);
            yield return null;
        }
    }
}
