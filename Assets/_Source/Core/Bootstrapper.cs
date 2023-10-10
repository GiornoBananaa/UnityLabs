using NuclearSystem.Time;
using NuclearSystem.View;
using TimerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ResourceButton[] resourceButtons;
        [SerializeField] private GameTimer gameTimer;
        [SerializeField] private GameObject lossPanel;
        [SerializeField] private Button lossRestartButton;

        private ResourceViewService _resourceViewService;
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(lossPanel,lossRestartButton, resourceButtons, gameTimer);
            ResourceTimerService.Instance.Construct(_game);
        }
    }
}
