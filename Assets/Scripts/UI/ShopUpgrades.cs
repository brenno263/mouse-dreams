using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopUpgrades : MonoBehaviour
{
    public GameObject GameManager;
    public PlayerData Player;
    public GameObject Damage;

    public List<ShopTextPair> texts;

    [Serializable]
    public class ShopTextPair
    {
        public UpgradeType type;
        public TextMeshProUGUI text;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Game Manager");
        Player = GameManager.GetComponent<PlayerData>();
        Player.onUpgradesChange += (upgrades =>
        {
            foreach (var pair in texts)
            {
                int upgradeLevel = Player.getUpgradeLevel(pair.type);
                pair.text.text = pair.type.ToString() + " " + upgradeLevel + "\n$" + Player.getUpgradeCost(pair.type);
            }
        });
        Player.onUpgradesChange(Player.Upgrades.getList());
    }

    public bool canPayFor(UpgradeType type)
    {
        return Player.getUpgradeCost(type) <= Player.Money;
    }
    
    public bool tryPayment(UpgradeType type)
    {
        int cost = Player.getUpgradeCost(type);
        if (canPayFor(type) && Player.tryUpgrade(type))
        {
            Player.Money -= cost;
            return true;
        }
        return false;
    }

    public void UpgradeRotSpeed()
    {
        tryPayment(UpgradeType.RotSpeed);
    }

    public void UpgradeWidth()
    {
        tryPayment(UpgradeType.Width);
    }

    public void UpgradeFirerate()
    {
        tryPayment(UpgradeType.FireRate);
    }

    public void UpgradeProfit()
    {
        tryPayment(UpgradeType.Profit);
    }

    public void UpgradeRange()
    {
        tryPayment(UpgradeType.Range);
    }

    public void UpgradeMaxhealth()
    {
        tryPayment(UpgradeType.MaxHealth);
    }

    public void Heal()
    {
        if( 100 <= Player.Money)
        {
            if(Player.tryHeal())
            {
                Player.Money -= 100;
            }
        }
    }


}
