using System;
using UnityEngine;

public class FormulaDataLoader : MonoBehaviour
{
    [SerializeField] private FormulaView[] _formulaViews;
    private FormulaViewDataSO _formulaViewData;

    private void Awake()
    {
        _formulaViewData = (FormulaViewDataSO)Resources.Load("FormulaViewData");

        foreach (var formulaView in _formulaViews)
        {
            formulaView.Construct(_formulaViewData);
        }
    }
}
