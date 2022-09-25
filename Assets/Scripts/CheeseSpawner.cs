using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CheeseSpawner : MonoBehaviour
{
    public List<Wave> waveData;
    public float spawnRadius;

    public int currentWave;

    public GameObject smallCheese;
    public GameObject mediumCheese;
    public GameObject largeCheese;

    // Start is called before the first frame update
    void Start()
    {
        nextWave();
        SceneManager.sceneLoaded += ((scene, mode) =>
        {
            if (scene.name == "Game") nextWave();
        });
    }

    public void nextWave()
    {
        if (currentWave == waveData.Count - 1)
        {
            SceneManager.LoadScene("Win");
            return;
        }
        Wave w = waveData[currentWave++];
        StartCoroutine(runWave(w));
    }

    public IEnumerator runWave(Wave w)
    {
        yield return new WaitForSeconds(2);
        int aliveCheeseCount = 0;
        bool failedToFinish = true;
        foreach (MicroWave mw in w.microWaves)
        {
            while (mw.hasNext())
            {
                CheeseType type = mw.next();
                GameObject go = smallCheese;
                switch (type)
                {
                    case CheeseType.Small:
                        go = smallCheese;
                        break;
                    case CheeseType.Medium:
                        go = mediumCheese;
                        break;
                    case CheeseType.Large:
                        go = largeCheese;
                        break;
                }

                Vector3 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
                GameObject instantiatedGo = Instantiate(go, spawnPos, go.transform.rotation);
                Cheese c = instantiatedGo.GetComponent<Cheese>();
                aliveCheeseCount++;
                c.onDeath = () =>
                {
                    aliveCheeseCount--;
                    if (aliveCheeseCount == 0)
                    {
                        failedToFinish = false;
                        goToShop();
                    }
                };

                float time = Random.Range(mw.spawnDelayRange.x, mw.spawnDelayRange.y);
                yield return new WaitForSeconds(time);
            }
        }

        yield return new WaitForSeconds(10f);
        if(failedToFinish) goToShop();
    }
    private void goToShop()
    {
        if (SceneManager.GetActiveScene().name != "Shop") ;
        SceneManager.LoadScene("Shop");
    }

    public enum CheeseType
    {
        Small,
        Medium,
        Large,
    }

    [Serializable]
    public class Wave
    {
        public List<MicroWave> microWaves;
    }

    [Serializable]
    public class MicroWave
    {
        public Vector2 spawnDelayRange;
        public int small;
        public int medium;
        public int large;

        public bool hasNext()
        {
            return small != 0 || medium != 0 || large != 0;
        }

        public CheeseType next()
        {
            if (!hasNext()) return CheeseType.Small;

            while (true)
            {
                if (!hasNext()) return CheeseType.Small;
                int typeIndex = (int)Random.Range(0, 3);
                switch (typeIndex)
                {
                    case 0:
                        if (small > 0)
                        {
                            small--;
                            return CheeseType.Small;
                        }

                        break;
                    case 1:
                        if (medium > 0)
                        {
                            medium--;
                            return CheeseType.Medium;
                        }

                        break;
                    case 2:
                        if (large > 0)
                        {
                            large--;
                            return CheeseType.Large;
                        }

                        break;
                }
            }
        }
    }
}