using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public static class FormulaCalculation
{
    private static PhysicsConstantsDataSO _constantsData = (PhysicsConstantsDataSO)Resources.Load("PhysicsConstantsData");

    public static float MassEnergyEquivalence(float mass)
    {
        return mass * _constantsData.LightSpeed * _constantsData.LightSpeed;
    }
    
    public static float ArchimedesForce(float density, float volume)
    {
        return density * _constantsData.GravitationalAcceleration * volume;
    }
    
    public static float BodyImpulse(float mass, float speed)
    {
        return mass * speed;
    }
    
    public static float BodyDensity(float mass, float volume)
    {
        return mass / volume;
    }
    
    public static float JouleLenz(float amperage,float resistance, float time)
    {
        return amperage * amperage * resistance * time;
    }
}
