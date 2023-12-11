using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class JouleLenzFormulaView : FormulaView
{
    [SerializeField] private TMP_InputField _amperageInputField;
    [SerializeField] private TMP_InputField _resistanceInputField;
    [SerializeField] private TMP_InputField _timeInputField;
    private float _amperageInput;
    private float _resistanceInput;
    private float _timeInput;

    protected override void FormulaTextSet(FormulaViewDataSO formulaViewData)
    {
        _formulaText.text = formulaViewData.JouleLenzFormula;
    }

    protected override float Calculate() => FormulaCalculation.JouleLenz(_amperageInput,_resistanceInput,_timeInput);
    
    protected override bool CheckInputFields()
    {
        if(!float.TryParse(_amperageInputField.text, out _amperageInput) 
           || !float.TryParse(_resistanceInputField.text, out _resistanceInput)
           || !float.TryParse(_timeInputField.text, out _timeInput))
            return false;
        return true;
    }
}
