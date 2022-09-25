using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void OnHealthChange(int _health, int _maxHealth);
public delegate void OnMoneyChange(int _startMoney, int _newMoney);

public class PlayerData : MonoBehaviour
{
    public int baseMaxHealth;
    public SerializableMap<UpgradeType, Upgrade> Upgrades;

    public OnHealthChange onHealthChange;
    public OnMoneyChange onMoneyChange;

    public int Health
    {
        get { return _health; }
        set
        {
            if (onHealthChange != null)
                onHealthChange(value, baseMaxHealth + getUpgradeLevel(UpgradeType.MaxHealth));
            _health = value;
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
    private int _money = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            onHealthChange = null;
            onMoneyChange = null;

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

    public bool tryUpgrade(UpgradeType type)
    {
        Upgrade u = Upgrades.get(type);
        return u.tryUpgrade();
    }

    public bool tryHeal()
    {
        if (Health < baseMaxHealth + getUpgradeLevel(UpgradeType.MaxHealth) * 2);
        {
            Health++;
            return true;
        }
        return false;
    }

    
}
