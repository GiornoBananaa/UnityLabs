using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BodyDensityFormulaView : FormulaView
{
    [SerializeField] private TMP_InputField _massInputField;
    [SerializeField] private TMP_InputField _volumeInputField;
    private float _massInput;
    private float _volumeInput;

    protected override void FormulaTextSet(FormulaViewDataSO formulaViewData)
    {
        _formulaText.text = formulaViewData.BodyDensityFormula;
    }

    protected override float Calculate() => FormulaCalculation.BodyDensity(_massInput,_volumeInput);
    
    protected override bool CheckInputFields()
    {
        if(!float.TryParse(_massInputField.text, out _massInput) || !float.TryParse(_volumeInputField.text, out _volumeInput))
            return false;
        return true;
    }
}
