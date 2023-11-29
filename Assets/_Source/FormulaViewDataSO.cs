using UnityEngine;

[CreateAssetMenu(menuName = "SO/new Formula View Data", fileName = "FormulaViewData")]
public class FormulaViewDataSO : ScriptableObject
{
    [field:SerializeField, TextArea,Tooltip("E-energy, m-mass, c-light speed")] 
    public string MassEnergyEquivalenceFormula { get; private set; }
    
    [field:SerializeField, TextArea,Tooltip("F-archimedes, p-density, g-gravitational acceleration const, V-volume")] 
    public string ArchimedesFormula { get; private set; }
    
    [field:SerializeField, TextArea,Tooltip("p-impulse, m-mass, v-speed")] 
    public string BodyImpulseFormula { get; private set; }
    
    [field:SerializeField, TextArea,Tooltip("p-density, m-mass, V-volume")] 
    public string BodyDensityFormula { get; private set; }
    
    [field:SerializeField, TextArea,Tooltip("Q-heat amount, I-amperage, R-resistance ,t-time")] 
    public string JouleLenzFormula { get; private set; }
}