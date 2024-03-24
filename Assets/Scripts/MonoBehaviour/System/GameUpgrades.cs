using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GameUpgrades : MonoBehaviour
    {
        [SerializeField] protected Button _meatButton;
        [SerializeField] protected Button _bankButton;
        [SerializeField] protected Button _tigerButton;
        
        [SerializeField] protected TextMeshProUGUI _tigerButtonCost;
        [SerializeField] protected TextMeshProUGUI _bankButtonCost;
        [SerializeField] protected TextMeshProUGUI _meatButtonCost;

        private ulong _meatShopUpgradeCost = 150;
        private ulong _bankUpgradeCost = 150;
        private ulong _tigerUpgradeCost = 2000;

        public void Init()
        {
            _meatButton.onClick.AddListener(BuyMeatShop);
            _bankButton.onClick.AddListener(BuyBank);
            _tigerButton.onClick.AddListener(BuyTiger);
            GameInstance.MoneyManager.OnCoinsCurrencyValueChange += CheckButtonsInteractable;
            GameInstance.MoneyManager.OnMeatCurrencyValueChange += CheckButtonsInteractable;
            CheckButtonsInteractable();
        }

        private void OnDestroy()
        {
            GameInstance.MoneyManager.OnCoinsCurrencyValueChange -= CheckButtonsInteractable;
            GameInstance.MoneyManager.OnMeatCurrencyValueChange -= CheckButtonsInteractable;
        }

        private void BuyMeatShop()
        {
            if (GameInstance.MoneyManager.HasEnoughCoinsCurrency(_meatShopUpgradeCost))
            {
                GameInstance.Levels.SpawnMeatShop(); 
                GameInstance.MoneyManager.SpendCoinsCurrency(_meatShopUpgradeCost);
                _meatShopUpgradeCost = 300; 
            }
        }
        
        private void BuyBank()
        {
            if (GameInstance.MoneyManager.HasEnoughMeatCurrency(_bankUpgradeCost))
            {
                GameInstance.Levels.SpawnBank();
                GameInstance.MoneyManager.SpendMeatCurrency(_bankUpgradeCost);
                _bankUpgradeCost = 300; 
            }
        }
        
        private void BuyTiger()
        {
            if (GameInstance.MoneyManager.HasEnoughCoinsCurrency(_tigerUpgradeCost))
            {
                GameInstance.MoneyManager.SpendCoinsCurrency(_tigerUpgradeCost);
                GameInstance.Levels.SpawnPlayer();
            }
        }

        private void CheckButtonsInteractable()
        {
            if (GameInstance.MoneyManager.HasEnoughCoinsCurrency(_tigerUpgradeCost))
            {
                _tigerButton.interactable = true;
            }
            else
            {
                _tigerButton.interactable = false;
            }
            
            if (GameInstance.MoneyManager.HasEnoughMeatCurrency(_bankUpgradeCost) && GameInstance.Levels.BankCount < 2)
            {
                _bankButton.interactable = true;
            }
            else
            {
                _bankButton.interactable = false;
            }
            
            if (GameInstance.MoneyManager.HasEnoughCoinsCurrency(_meatShopUpgradeCost) && GameInstance.Levels.MeatShopCount < 2)
            {
                _meatButton.interactable = true;
            }
            else
            {
                _meatButton.interactable = false;
            }

            SetCostText();
        }

        private void SetCostText()
        {
            _meatButtonCost.SetText(GameInstance.Levels.MeatShopCount < 2 ? _meatShopUpgradeCost.ToString() : "MAX");
            _bankButtonCost.SetText(GameInstance.Levels.BankCount < 2 ? _bankUpgradeCost.ToString() : "MAX");
            _tigerButtonCost.SetText(_tigerUpgradeCost.ToString());
        }
    }
}