using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public float maxHealth;
    public SerializableMap<UpgradeType, Upgrade> Upgrades;
    
    [Header("Set Dynamically")]
    public float health;
    public float money;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name != "Game" && scene.name != "Shop")
            {
                Destroy(gameObject);
            }
        };

        health = maxHealth;
        money = 0;
    }

    public int getUpgradeLevel(UpgradeType type)
    {
        Upgrade u = Upgrades.get(type);
        return u.currentLevel;
    }

    public bool tryUpgrade(UpgradeType type)
    {
        Upgrade u = Upgrades.get(type);
        return u.tryUpgrade();
    }
}
