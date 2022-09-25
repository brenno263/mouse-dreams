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

    public bool tryPayment(UpgradeType type)
    {
        int cost = Player.getUpgradeCost(type);
        if (cost <= Player.Money)
        {
            Player.Money -= cost;
            return true;
        }
        return false;
    }

    public void UpgradeDamage()
    {
        if(tryPayment(UpgradeType.Damage)) Player.tryUpgrade(UpgradeType.Damage);
    }

    public void UpgradeWidth()
    {
        if(tryPayment(UpgradeType.Width)) Player.tryUpgrade(UpgradeType.Width);

    }

    public void UpgradeFirerate()
    {
        if(tryPayment(UpgradeType.FireRate)) Player.tryUpgrade(UpgradeType.FireRate);

    }

    public void UpgradeProfit()
    {
        if(tryPayment(UpgradeType.Profit)) Player.tryUpgrade(UpgradeType.Profit);

    }

    public void UpgradeRange()
    {
        if(tryPayment(UpgradeType.Range)) Player.tryUpgrade(UpgradeType.Range);
    }

    public void UpgradeMaxhealth()
    {
        if(tryPayment(UpgradeType.MaxHealth)) Player.tryUpgrade(UpgradeType.MaxHealth);
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
