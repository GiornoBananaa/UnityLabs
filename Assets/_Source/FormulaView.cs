using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class FormulaView: MonoBehaviour
{
    [SerializeField] protected Button _calculateButton;
    [SerializeField] protected TMP_Text _formulaText;
    [SerializeField] private TMP_Text _result;

    public void Construct(FormulaViewDataSO formulaViewDataSo)
    {
        FormulaTextSet(formulaViewDataSo);
    }
    
    protected void Awake()
    {
        _calculateButton.onClick.AddListener(PrintResult);
    }
    
    protected abstract void FormulaTextSet(FormulaViewDataSO formulaViewData);
    protected abstract float Calculate();
    protected abstract bool CheckInputFields();

    private void PrintResult()
    {
        if (!CheckInputFields()) return;
        _result.text = Calculate().ToString("F", CultureInfo.InvariantCulture);
    }
}