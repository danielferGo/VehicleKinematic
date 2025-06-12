using UnityEngine;
using UnityEngine.Events;

public class StepData : MonoBehaviour
{
    public string title;
    public string instruction;
    public Sprite icon;
    public AudioClip narration;
    public UnityEvent onStepCompleted; // Event to trigger when the step is completed
    public UnityEvent onStepStarted; // Event to trigger when the step is started
    public UnityEvent onResetStep;
    public UnityEvent onPlaybackComplete;
}