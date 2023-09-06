using PlayerSystem;
using TMPro;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode jumpKey;
        [SerializeField] private KeyCode shootKey;
        [SerializeField] private Player player;
        [SerializeField] private TMP_Text inputStateText;
        private PlayerInvoker _playerInvoker;
        private bool _isInputOn;

        private void Awake()
        {
            _isInputOn = true;
            _playerInvoker = new PlayerInvoker(player);
        }

        private void Update()
        {
            if (_isInputOn)
            {
                ReadJumpKey();
                ReadMove();
                ReadRotate();
                ReadShoot();
            }
            
            ReadOffInputKey();
            ReadOnInputKey();
        }

        private void ReadMove()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            
            Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical );
            
            _playerInvoker.Move(moveDirection);
        }
        
        private void ReadRotate()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var rayCastHit))
            {
                _playerInvoker.Rotate(rayCastHit.point);
            }
        }

        private void ReadJumpKey()
        {
            if (Input.GetKeyDown(jumpKey))
            {
                _playerInvoker.Jump();
            }
        }
       
        private void ReadShoot()
        {
            if (Input.GetKeyDown(shootKey))
            {
                _playerInvoker.Shoot();
            }
        }
        
        private void ReadOffInputKey()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isInputOn = false;
                inputStateText.gameObject.SetActive(true);
            }
        }
        private void ReadOnInputKey()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isInputOn = true;
                inputStateText.gameObject.SetActive(false);
            }
        }
    }
}
