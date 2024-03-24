using Level;
using Player;
using Settings;
using UnityEngine;
using UserInterface;

namespace System
{
    public class GameInstance : Singleton<GameInstance>
    {
        [SerializeField] private LevelMaster _levelMaster;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private MoneyManager _moneyManager;
        [SerializeField] private GameUpgrades _gameUpgrades;
        
        public static LevelMaster Levels => Default._levelMaster;
        public static UIManager UI => Default._uiManager;
        public static MoneyManager MoneyManager => Default._moneyManager;
        public static GameUpgrades GameUpgrades => Default._gameUpgrades;

        protected override void Awake()
        {
            base.Awake();
            _levelMaster.Init();
            _moneyManager.Init(0);
            _gameUpgrades.Init();
        }
    }
}