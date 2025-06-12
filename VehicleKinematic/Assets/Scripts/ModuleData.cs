using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PhysicsXR/Module")]
public class ModuleData : ScriptableObject
{
    public string moduleName;
    public string summary;
    public List<ExerciseData> exercises;
    public Sprite thumbnail;
}