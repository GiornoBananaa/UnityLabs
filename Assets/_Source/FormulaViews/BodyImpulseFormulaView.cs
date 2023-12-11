using TMPro;
using UnityEngine;

public class BodyImpulseFormulaView : FormulaView
{
    [SerializeField] private TMP_InputField _massInputField;
    [SerializeField] private TMP_InputField _speedInputField;
    private float _massInput;
    private float _speedInput;

    protected override void FormulaTextSet(FormulaViewDataSO formulaViewData)
    {
        _formulaText.text = formulaViewData.BodyImpulseFormula;
    }

    protected override float Calculate() => FormulaCalculation.BodyImpulse(_massInput,_speedInput);
    
    protected override bool CheckInputFields()
    {
        if(!float.TryParse(_massInputField.text, out _massInput) || !float.TryParse(_speedInputField.text, out _speedInput))
            return false;
        return true;
    }
}
