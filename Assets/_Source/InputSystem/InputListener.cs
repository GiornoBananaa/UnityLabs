using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private Player _player;
        
        public void Constructor(Player player)
        {
            _player = player;
        }

        private void Update()
        {
            ReadPlayerMove();
        }

        private void ReadPlayerMove()
        {
            float x = Input.GetAxis("Vertical");
            float y = Input.GetAxis("Horizontal");
            
            _player.MovePlayer(new Vector3(x,y));
        }
    }
}
