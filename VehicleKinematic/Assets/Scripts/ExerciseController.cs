using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;

public abstract class ExerciseController : MonoBehaviour
{
    public ExerciseData exerciseData;
    public List<StepData> steps;
    public List<GameObject> stepObjects;
    public int currentStepIndex = 0;
    public abstract void InitializeExercise(); // Setup objects, spawn terrain
    public abstract void ResetExercise(); // Reset to initial state

    public abstract void ResetStep();
    public abstract void ApplyUserInputs(Dictionary<string, float> variables); // Mass, velocity, etc.
    protected abstract void CleanupExercise(); // Destroy objects if needed

    public UnityEvent onExerciseComplete;

    public static void LoadExercise(ExerciseData data)
    {
        // Spawn logic
        var logicInstance = Instantiate(data.exerciseLogicPrefab);

        // Spawn all required objects
        foreach (var prefab in data.objectPrefabs)
        {
            Instantiate(prefab);
        }

        // Optionally initialize with default values
    }

    public virtual void OnStepStar()
    {
        if (currentStepIndex < 0 || currentStepIndex >= steps.Count)
        {
            Debug.LogError("Invalid step index: " + currentStepIndex);
            return;
        }

        StepData currentStep = steps[currentStepIndex];
        currentStep.gameObject.SetActive(true);
        currentStep.onStepStarted.Invoke();
    }

    public virtual void OnStepComplete()
    {
        if (currentStepIndex < 0 || currentStepIndex >= steps.Count)
        {
            Debug.LogError("Invalid step index: " + currentStepIndex);
            return;
        }

        StepData currentStep = steps[currentStepIndex];
        currentStep.onStepCompleted.Invoke();
        currentStepIndex++;
        if (currentStepIndex >= steps.Count)
        {
            onExerciseComplete.Invoke();
            return;
        }

        OnStepStar();
    }

    protected virtual void OnExerciseComplete()
    {
        onExerciseComplete.Invoke();
        CleanupExercise();
    }
}