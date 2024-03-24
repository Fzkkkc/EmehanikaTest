using System;
using TMPro;
using UnityEngine;

namespace UserInterface
{
    public class UITextMoney : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;
        [SerializeField] private bool _isCoinsCurrency;
        
        protected void Start()
        {
            if (_isCoinsCurrency)
            {
                GameInstance.MoneyManager.OnCoinsCurrencyChange += OnMoneyChanged;
                OnMoneyChanged(GameInstance.MoneyManager.GetCoinsCurrency());
            }
            else
            {
                GameInstance.MoneyManager.OnMeatCurrencyChange += OnMoneyChanged;
                OnMoneyChanged(GameInstance.MoneyManager.GetMeatCurrency());
            }
        }
        
        private void OnDestroy()
        {
            if (_isCoinsCurrency)
            {
                GameInstance.MoneyManager.OnCoinsCurrencyChange -= OnMoneyChanged;
            }
            else
            {
                GameInstance.MoneyManager.OnMeatCurrencyChange -= OnMoneyChanged;
            }
        }
        
        private void OnMoneyChanged(ulong money) 
        {
            _currencyText.SetText(money.ToString());
        }
    }
}