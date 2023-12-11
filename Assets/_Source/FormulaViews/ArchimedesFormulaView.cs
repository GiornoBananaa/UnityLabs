using TMPro;
using UnityEngine;

public class ArchimedesFormulaView : FormulaView
{
    [SerializeField] private TMP_InputField _densityInputField;
    [SerializeField] private TMP_InputField _volumeInputField;
    private float _densityInput;
    private float _volumeInput;

    protected override void FormulaTextSet(FormulaViewDataSO formulaViewData)
    {
        _formulaText.text = formulaViewData.ArchimedesFormula;
    }

    protected override float Calculate() => FormulaCalculation.ArchimedesForce(_densityInput,_volumeInput);
    
    protected override bool CheckInputFields()
    {
        if(!float.TryParse(_densityInputField.text, out _densityInput) || !float.TryParse(_volumeInputField.text, out _volumeInput))
            return false;
        return true;
    }
}
