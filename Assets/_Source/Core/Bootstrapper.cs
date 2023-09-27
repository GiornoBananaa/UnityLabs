using ClickSystem;
using InputSystem;
using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private ClickableComponent goodClickableComponent;
        [SerializeField] private ClickableComponent badClickableComponent;
        [SerializeField] private ScoreView scoreView;
        private Game _game;
        private Score _score;

        private void Awake()
        {
            Init();
            StartGame();
        }

        private void Init()
        {
            _score = new Score();
            _game = new Game(_score);
            inputListener.Construct(_game);
            goodClickableComponent.Construct(_score,true);
            badClickableComponent.Construct(_score,false);
            scoreView.Construct(_score);
        }

        private void StartGame()
        {
            _game.OnApplicationStart();
        }
    }
}
