using System;
using UnityEngine;

namespace Settings
{
    public class MoneyManager : MonoBehaviour
    {
        private ulong _meatCurrency;
        private ulong _coins;
        public Action<ulong> OnMeatCurrencyChange;
        public Action OnMeatCurrencyValueChange;
        public Action<ulong> OnCoinsCurrencyChange;
        public Action OnCoinsCurrencyValueChange;
        
        public void Init(ulong startMoney)
        {
            AddMeatCurrency(startMoney);
            AddCoinsCurrency(startMoney);
        }
        
        public ulong GetMeatCurrency()
        {
            return _meatCurrency;
        }
        
        public ulong GetCoinsCurrency()
        {
            return _coins;
        }
        
        public void AddMeatCurrency(ulong count)
        {
            _meatCurrency = (_meatCurrency + count);
            OnMeatCurrencyChange?.Invoke(_meatCurrency);
            OnMeatCurrencyValueChange?.Invoke();
        }
        
        public void AddCoinsCurrency(ulong count)
        {
            _coins = (_coins + count);
            OnCoinsCurrencyChange?.Invoke(_coins);
            OnCoinsCurrencyValueChange?.Invoke();
        }
        
        public void SpendMeatCurrency(ulong count)
        {
            ulong result = 0UL;
            if (_meatCurrency >= count)
                result = _meatCurrency - count;
            _meatCurrency = result;
            OnMeatCurrencyChange?.Invoke(_meatCurrency);
            OnMeatCurrencyValueChange?.Invoke();
        }
        
        public void SpendCoinsCurrency(ulong count)
        {
            ulong result = 0UL;
            if (_coins >= count)
                result = _coins - count;
            _coins = result;
            OnCoinsCurrencyChange?.Invoke(_coins);
            OnCoinsCurrencyValueChange?.Invoke();
        }
    
        public bool HasEnoughMeatCurrency(ulong amount)
        {
            return _meatCurrency >= amount;
        }
        
        public bool HasEnoughCoinsCurrency(ulong amount)
        {
            return _coins >= amount;
        }
    }
}