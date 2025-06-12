using System.Collections.Generic;
using Meta.WitAi.TTS.Utilities;
using UnityEngine;

public class LinearMotionExercise : ExerciseController
{
    [SerializeField] private CarConfigurable carConfigurable;
    [SerializeField] private TTSSpeaker speaker;

    private void Start()
    {
        speaker.Events.OnPlaybackQueueComplete.AddListener(OnPlaybackComplete);
        InitializeExercise();
    }

    private void OnPlaybackComplete()
    {
        StepData currentStep = steps[currentStepIndex];
        currentStep.onPlaybackComplete.Invoke();
    }


    public override void InitializeExercise()
    {
        ExecuteStep();
    }

    private void ExecuteStep()
    {
        StepData currentStep = steps[currentStepIndex];
        currentStep.onStepStarted.Invoke();
    }

    public override void ApplyUserInputs(Dictionary<string, float> variables)
    {
        carConfigurable.ApplyProperty("mass", 1f);
    }

    public override void ResetExercise()
    {
        InitializeExercise();
    }

    public override void ResetStep()
    {
        if (currentStepIndex < 0 || currentStepIndex >= steps.Count)
        {
            Debug.LogError("Invalid step index: " + currentStepIndex);
            return;
        }

        StepData currentStep = steps[currentStepIndex];
        currentStep.onResetStep.Invoke();
    }


    protected override void CleanupExercise()
    {
    }

    public override void OnStepComplete()
    {
        Debug.Log("LinearMotionExercise.OnStepComplete");
        steps[currentStepIndex].gameObject.SetActive(false);
        base.OnStepComplete();
    }
}