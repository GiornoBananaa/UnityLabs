using System;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class ResourceAddingPanel : MonoBehaviour
    {
        //TODO ui
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private Button _addButton;

        private void Awake()
        {
            _addButton.onClick.AddListener(AddButton);
        }

        private void AddButton()
        {
            int quantity = 0;
            int.TryParse(_inputField.text, out quantity);
            
            ResourceBank.Instance.AddResource((ResourceType)_dropdown.value, quantity);
        }
    }
}
