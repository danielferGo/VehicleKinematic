using UnityEngine;
using UnityEngine.Events;

public class DisplacementStep : StepData
{
    public CarConfigurable car;
    public GameObject copyCarPrefab;
    public float dataDisplayInterval = 1f;
    private float _dataDisplayTimer;

    public Transform initialPosition;
    public Transform finalPosition;
    private float initialTime;
    private float finalTime;
    private float displacementMagnitude;
    private float velocityMagnitude;

    private bool isVisualizationEnabled;
    private float currentSimulationTime;

    public bool isEvaluationEnabled;

    public UnityEvent onSimulationEnd;
    public UnityEvent onEvaluationComplete;
    public UnityEvent onEvaluationError;

    private void Start()
    {
        var properties = car.GetProperties();

        initialPosition.localPosition = new Vector3(0, 0, properties["initialPosition"].defaultValue);
        finalPosition.localPosition = new Vector3(0, 0, properties["finalPosition"].defaultValue);
        velocityMagnitude = properties["velocity"].defaultValue;
        initialTime = properties["initialTime"].defaultValue;
        finalTime = properties["finalTime"].defaultValue;

        Vector3 displacementVector = finalPosition.localPosition - initialPosition.localPosition;
        displacementMagnitude = displacementVector.magnitude;
        // velocityMagnitude = displacementMagnitude / (finalTime - initialTime);
        car.transform.localPosition = initialPosition.localPosition;
        currentSimulationTime = initialTime;
        _dataDisplayTimer = 0f;
    }

    private void Update()
    {
        if (!isVisualizationEnabled) return;
        var time = Time.fixedDeltaTime;
        _dataDisplayTimer += time;
        currentSimulationTime += time;

        if (currentSimulationTime >= finalTime)
        {
            isVisualizationEnabled = false;
            ShowData(currentSimulationTime - time, "f");
            onSimulationEnd.Invoke();
            if (isEvaluationEnabled) EvaluateStep();
            return;
        }

        if (_dataDisplayTimer >= dataDisplayInterval)
        {
            ShowData(currentSimulationTime - time);
            _dataDisplayTimer -= dataDisplayInterval;
        }


        if (isEvaluationEnabled)
        {
            MoveByVelocity();
        }
        else
        {
            MoveByDisplacement();
        }
    }

    public void ResetStep()
    {
        Debug.Log("DisplacementStep.ResetStep");
        var properties = car.GetProperties();
        initialPosition.localPosition = new Vector3(0, 0, properties["initialPosition"].defaultValue);
        finalPosition.localPosition = new Vector3(0, 0, properties["finalPosition"].defaultValue);
        velocityMagnitude = properties["velocity"].defaultValue;

        initialTime = properties["initialTime"].defaultValue;
        finalTime = properties["finalTime"].defaultValue;
        Vector3 displacementVector = finalPosition.localPosition - initialPosition.localPosition;
        displacementMagnitude = displacementVector.magnitude;
        // velocityMagnitude = displacementMagnitude / (finalTime - initialTime);
        car.rb.linearVelocity = Vector3.zero;

        car.transform.localPosition = initialPosition.localPosition;


        foreach (var copy in GameObject.FindGameObjectsWithTag("CopyStep"))
        {
            Destroy(copy);
        }

        currentSimulationTime = initialTime;
        _dataDisplayTimer = 0f;
    }

    public void StartVisualization()
    {
        Debug.Log("DisplacementStep.StartVisualization");
        isVisualizationEnabled = true;
        _dataDisplayTimer = 0f;
        currentSimulationTime = initialTime;
        ShowData(currentSimulationTime, "i");
    }

    private void ShowData(float time, string position = null)
    {
        var copy = Instantiate(copyCarPrefab, car.transform.position, car.transform.rotation);
        var formula = $"x{position} = {car.transform.position.z:F2} \n" + $"t{position} = {time:F2} \n";
        copy.GetComponent<FormulaDisplay>().SetFormula(formula);
    }


    private void MoveByDisplacement()
    {
        var t = currentSimulationTime / (finalTime - initialTime);
        car.transform.localPosition =
            Vector3.Lerp(initialPosition.localPosition, finalPosition.localPosition, Mathf.Clamp01(t));
    }

    private void MoveByVelocity()
    {
        // COMPLETE THE CODE HERE: Move the car directly by the user's velocity input
        // Position = Initial_Position + (Direction * Velocity * Time_Elapsed)
        float distanceTraveled = velocityMagnitude * (currentSimulationTime - initialTime);
        car.transform.localPosition = initialPosition.localPosition +
                                      (finalPosition.localPosition - initialPosition.localPosition).normalized *
                                      distanceTraveled;
    }

    private void EvaluateStep()
    {
        Debug.Log(finalPosition.localPosition);
        Debug.Log(car.transform.localPosition);
        if (finalPosition.localPosition == car.transform.localPosition)
        {
            onEvaluationComplete.Invoke();
        }
        else
        {
            onEvaluationError.Invoke();
        }
    }
}