using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void OnHealthChange(int _health, int _maxHealth);
public delegate void OnMoneyChange(int _startMoney, int _newMoney);

public delegate void OnUpgradesChange(List<SerializableMap<UpgradeType, Upgrade>.Pair> upgrades);

public class PlayerData : MonoBehaviour
{
    public static GameObject gameManager;
    
    public int baseMaxHealth;
    public SerializableMap<UpgradeType, Upgrade> Upgrades;

    public OnHealthChange onHealthChange;
    public OnMoneyChange onMoneyChange;
    public OnUpgradesChange onUpgradesChange;

    public int Health
    {
        get { return _health; }
        set
        {
            if (onHealthChange != null)
                onHealthChange(value, baseMaxHealth + getUpgradeLevel(UpgradeType.MaxHealth));
            _health = value;
            if (_health <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
    private int _health = 0;

    public int Money
    {
        get { return _money; }
        set
        {
            if (onMoneyChange != null)
                onMoneyChange(_money, value);
            _money = value;
        }
    }
    private int _money;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = gameObject;
        
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            onHealthChange = null;
            onMoneyChange = null;
            onUpgradesChange = null;

            if (scene.name != "Game" && scene.name != "Shop")
            {
                Destroy(gameObject);
            }
        };

        Health = baseMaxHealth;
        Money = 0;
    }

    public int getUpgradeLevel(UpgradeType type)
    {
        Upgrade u = Upgrades.get(type);
        return u.currentLevel;
    }

    public int getUpgradeCost(UpgradeType type)
    {
        return (getUpgradeLevel(type) + 1) * 100;
    }

    public bool tryUpgrade(UpgradeType type)
    {
        Upgrade u = Upgrades.get(type);
        bool success = u.tryUpgrade();
        if (success) onUpgradesChange(Upgrades.getList());
        return u.tryUpgrade();
    }

    public bool tryHeal()
    {
        if (Health < baseMaxHealth + getUpgradeLevel(UpgradeType.MaxHealth) * 2)
        {
            Health++;
            return true;
        }
        return false;
    }

    
}
