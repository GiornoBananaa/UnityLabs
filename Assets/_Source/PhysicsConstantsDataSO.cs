using UnityEngine;

[CreateAssetMenu(menuName = "SO/new Physics Constants Data", fileName = "PhysicsConstantsData")]
public class PhysicsConstantsDataSO : ScriptableObject
{
    [field:SerializeField] public float GravitationalAcceleration { get; private set; }
    [field:SerializeField] public float LightSpeed { get; private set; }
}