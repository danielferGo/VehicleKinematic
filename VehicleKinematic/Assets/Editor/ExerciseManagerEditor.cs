using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LinearMotionExercise))]
public class ExerciseManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LinearMotionExercise manager = (LinearMotionExercise)target;

        if (GUILayout.Button("Next Step"))
        {
            manager.OnStepComplete();
        }
        
        if (GUILayout.Button("Reset Step"))
        {
            manager.ResetStep();
        }
    }
}