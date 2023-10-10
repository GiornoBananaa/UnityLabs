using System.Collections.Generic;
using NuclearSystem;
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

            foreach (var button in resourceButtons)
            {
                button.Construct(_game);
            }
        }
    }
}
