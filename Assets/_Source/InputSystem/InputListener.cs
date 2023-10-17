using System;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private CharacterShooter characterShooter;
        [SerializeField] private KeyCode shootKeyCode;

        private void Update()
        {
            CheckSoot();
        }

        private void CheckSoot()
        {
            if (Input.GetKeyDown(shootKeyCode))
            {
                characterShooter.Shoot();
            }
        }
    }
}
