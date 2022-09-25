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
                pair.text.text = pair.type.ToString() + " " + upgradeLevel + "\n$" + 100 * upgradeLevel;
            }
        });
    }

    public bool tryPayment(UpgradeType type)
    {

        int upgradeLevel = Player.getUpgradeLevel(type);

        if ((upgradeLevel * 100) <= Player.Money)
        {
            Debug.Log("Payment Is Possible");
            return true;
        }
        else
        {
            Debug.Log("Payment Is Not Possible");
            return false;
        }

    }

    public void UpgradeDamage()
    {
        if(tryPayment(UpgradeType.Damage) == true)
        {

            if(Player.tryUpgrade(UpgradeType.Damage) == true)
            {
                Debug.Log("Damage Upgrade Is Possible");
                Player.Money -= Player.getUpgradeLevel(UpgradeType.Damage) * 100;
            }
            else
            {
                Debug.Log("You could pay but couldn't upgrade!");
            }

        }
        
    }

    public void UpgradeWidth()
    {
        if (tryPayment(UpgradeType.Width) == true)
        {

            if (Player.tryUpgrade(UpgradeType.Width) == true)
            {
                Player.Money -= Player.getUpgradeLevel(UpgradeType.Width) * 100;
            }
            else
            {

            }

        }
    }

    public void UpgradeFirerate()
    {
        if (tryPayment(UpgradeType.FireRate) == true)
        {

            if (Player.tryUpgrade(UpgradeType.FireRate) == true)
            {
                Player.Money -= Player.getUpgradeLevel(UpgradeType.FireRate) * 100;
            }
            else
            {

            }

        }
    }

    public void UpgradeProfit()
    {
        if (tryPayment(UpgradeType.Profit) == true)
        {

            if (Player.tryUpgrade(UpgradeType.Profit) == true)
            {
                Player.Money -= Player.getUpgradeLevel(UpgradeType.Profit) * 100;
            }
            else
            {

            }

        }
    }

    public void UpgradeRange()
    {
        if (tryPayment(UpgradeType.Range) == true)
        {

            if (Player.tryUpgrade(UpgradeType.Range) == true)
            {
                Player.Money -= Player.getUpgradeLevel(UpgradeType.Range) * 100;
            }
            else
            {

            }

        }
    }

    public void UpgradeMaxhealth()
    {
        if (tryPayment(UpgradeType.MaxHealth) == true)
        {

            if (Player.tryUpgrade(UpgradeType.MaxHealth) == true)
            {
                Player.Money -= Player.getUpgradeLevel(UpgradeType.MaxHealth) * 100;
            }
            else
            {

            }

        }
    }

    public void Heal()
    {
        if( 100 <= Player.Money)
        {
            if(Player.tryHeal() == true)
            {
                Player.Money -= 100;
            }
        }
        
    }


}
