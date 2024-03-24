using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using Player;
using UnityEngine;

namespace Level
{
    public class LevelMaster : MonoBehaviour
    {
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Character _tigerPrefab;
        [SerializeField] private GameObject _meatShopPrefab;
        [SerializeField] private GameObject _bankPrefab;
        
        [SerializeField] private Transform[] _meatShopSpawnPoints; 
        [SerializeField] private Transform[] _bankSpawnPoints;
        
        private bool _hasSpline;
        private Character _player;
        private List<Character> _spawnedCharacters = new List<Character>();
        
        [HideInInspector] public int MeatShopCount = 0;
        [HideInInspector] public int BankCount = 0;
        
        public void Init()
        {
            _hasSpline = _spline != null;
            SpawnPlayer();
            GameInstance.UI.Input.OnInputDown += SpeedBoostTiger;
        }

        private void OnDestroy()
        {
            GameInstance.UI.Input.OnInputDown -= SpeedBoostTiger;
        }

        private void SpeedBoostTiger()
        {
            foreach (var character in _spawnedCharacters)
            {
                character.Movement.BoostSpeedForDuration();
            }
        }

        public void SpawnPlayer()
        {
            var tmpTiger = Instantiate(_tigerPrefab);
            
            _player = tmpTiger;
            _player.transform.SetParent(transform);
            
            _player.transform.position = _playerSpawnPoint.position;
            _player.transform.rotation = _playerSpawnPoint.rotation;
            
            if (_hasSpline)
                _player.Movement.SetSpline(_spline);
            
            AddSpawnedCharacter(_player);
        }
        
        private void AddSpawnedCharacter(Character character)
        {
            _spawnedCharacters.Add(character);
        }
        
        public void SpawnMeatShop()
        {
            if (MeatShopCount < 2 && _meatShopSpawnPoints.Length > MeatShopCount)
            {
                var spawnTransform = _meatShopSpawnPoints[MeatShopCount];
                var meatShop = Instantiate(_meatShopPrefab, spawnTransform.transform.parent);
                meatShop.transform.position = spawnTransform.transform.position;
                meatShop.transform.rotation = spawnTransform.transform.rotation;
                MeatShopCount++;
            }
        }
        
        public void SpawnBank()
        {
            if (BankCount < 2 && _bankSpawnPoints.Length > BankCount)
            {
                var spawnTransform = _bankSpawnPoints[BankCount];
                var bank = Instantiate(_bankPrefab, spawnTransform.transform.parent);
                bank.transform.position = spawnTransform.transform.position;
                bank.transform.rotation = spawnTransform.transform.rotation;
                BankCount++;
            }
        }
    }
}
