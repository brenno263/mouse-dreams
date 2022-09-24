
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public int maxLevel;
    [NonSerialized]
    public int currentLevel;

    public Upgrade()
    {
        currentLevel = 0;
    }

    public bool tryUpgrade()
    {
        if (currentLevel >= maxLevel) return false;
        currentLevel++;
        return true;
    }
}

public enum UpgradeType
{
    Range,
    Width,
    Damage,
    FireRate,
    Profit,
    MaxHealth,
}