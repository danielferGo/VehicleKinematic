using UnityEngine;

[CreateAssetMenu(menuName = "PhysicsXR/Formula")]
public class Formula : ScriptableObject
{
    public string rawEquation; // e.g., "F = m × a"
    public string[] variables; // e.g., ["F", "m", "a"]
    public string description; // "Force equals mass times acceleration"
}