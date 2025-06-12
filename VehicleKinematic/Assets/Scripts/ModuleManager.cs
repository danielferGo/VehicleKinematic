using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public ModuleData currentModule;

    private int currentExerciseIndex = 0;
    private int currentStepIndex = 0;
    private ExerciseData exerciseData;

    // private void Start()
    // {
    //     StartModule(currentModule);
    // }
    //
    // private void StartModule(ModuleData module)
    // {
    //     currentModule = module;
    //     currentExerciseIndex = 0;
    //     exerciseData = module.exercises[currentExerciseIndex];
    //     
    //     ExerciseController.LoadExercise(exerciseData);
    //     exerciseData.exerciseController.onExerciseComplete.AddListener(CompleteExercise);
    // }

    // void CompleteExercise()
    // {
    //     exerciseData.exerciseController.onExerciseComplete.RemoveListener(CompleteExercise);
    //     currentExerciseIndex++;
    //     if (currentExerciseIndex < currentModule.exercises.Count)
    //     {
    //         exerciseData = currentModule.exercises[currentExerciseIndex];
    //         ExerciseController.LoadExercise(exerciseData);
    //         exerciseData.exerciseController.onExerciseComplete.AddListener(CompleteExercise);
    //     }
    //     else
    //         Debug.Log("Module completed!");
    // }
}