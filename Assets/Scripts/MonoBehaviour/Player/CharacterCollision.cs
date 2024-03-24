using System;
using UnityEngine;

namespace Player
{
    public class CharacterCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bank"))
            {
                GameInstance.MoneyManager.AddCoinsCurrency(5);
            }
            else if (other.CompareTag("Butchery"))
            {
                GameInstance.MoneyManager.AddMeatCurrency(7);
            }
        }
    }
}