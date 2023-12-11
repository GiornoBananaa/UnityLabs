using TMPro;
using UnityEngine;

public class MassEnergyEquivalenceFormulaView : FormulaView
{
    [SerializeField] private TMP_InputField _massInputField;
    private float _massInput;

    protected override void FormulaTextSet(FormulaViewDataSO formulaViewData)
    {
        _formulaText.text = formulaViewData.MassEnergyEquivalenceFormula;
    }

    protected override float Calculate() => FormulaCalculation.MassEnergyEquivalence(_massInput);
    
    protected override bool CheckInputFields()
    {
        if(!float.TryParse(_massInputField.text, out _massInput))
            return false;
        return true;
    }
}
