using Core;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode restartKey;
        private Game _game;

        public void Construct(Game game)
        {
            _game = game;
        }
        
        private void Update()
        {
            ReadRestart();
        }

        private void ReadRestart()
        {
            if (Input.GetKeyDown(restartKey))
            {
                _game.Restart();
            }
        }
    }
}
