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
        [SerializeField] private TMP_Text _gunpowderQuantityText;
        [SerializeField] private TMP_Text _oilQuantityText;
        [SerializeField] private TMP_Text _uraniumQuantityText;

        private void Awake()
        {
            _addButton.onClick.AddListener(AddButton);
            _dropdown.options.Clear();
            _dropdown.options.Add(new TMP_Dropdown.OptionData("Gunpowder"));
            _dropdown.options.Add(new TMP_Dropdown.OptionData("Oil"));
            _dropdown.options.Add(new TMP_Dropdown.OptionData("Uranium"));
            UpdateQuantity();
        }

        private void AddButton()
        {
            int quantity = 0;
            int.TryParse(_inputField.text, out quantity);
            ResourceBank.Instance.AddResource((ResourceType)_dropdown.value, quantity);
            UpdateQuantity();
        }

        private void UpdateQuantity()
        {
            _gunpowderQuantityText.text = ResourceBank.Instance.GetQuantity(ResourceType.Gunpowder).ToString();
            _oilQuantityText.text = ResourceBank.Instance.GetQuantity(ResourceType.Oil).ToString();
            _uraniumQuantityText.text = ResourceBank.Instance.GetQuantity(ResourceType.Uranium).ToString();
        }
    }
}
