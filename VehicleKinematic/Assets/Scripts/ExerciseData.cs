using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PhysicsXR/ExerciseData")]
public class ExerciseData : ScriptableObject
{
    public string exerciseTitle;
    public GameObject exerciseLogicPrefab; // Contains the logic (inherits from ExerciseController)
    public List<GameObject> objectPrefabs; // Cars, paths, ramps, etc.
    public string description;
    public List<Formula> formulas;
    
}