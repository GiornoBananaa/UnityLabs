using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKeyCode;
        private CharacterShooter _characterShooter;

        public void Construct(CharacterShooter characterShooter)
        {
            _characterShooter = characterShooter;
        }
        
        private void Update()
        {
            CheckSoot();
        }

        private void CheckSoot()
        {
            if (Input.GetKeyDown(shootKeyCode))
            {
                _characterShooter.Shoot();
            }
        }
    }
}
