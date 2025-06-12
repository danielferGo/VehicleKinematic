using System.Collections.Generic;
using UnityEngine;

public class CarConfigurable : MonoBehaviour, IConfigurableObject
{
    public Rigidbody rb;
    public float mass = 1f;
    public float velocity = 2f;
    public float initialPosition;
    public float finalPosition = 3f;
    public float initialTime;
    public float finalTime = 3f;

    public bool activeMass = true;
    public bool activeVelocity = true;
    public bool activeInitialPosition = true;
    public bool activeFinalPosition = true;
    public bool activeInitialTime = true;
    public bool activeFinalTime = true;


    private Dictionary<string, ConfigurableProperty> _properties;

    public string GetDisplayName() => "Car";

    public void Awake()
    {
        _properties = new Dictionary<string, ConfigurableProperty>
        {
            {
                "mass",
                new ConfigurableProperty()
                {
                    key = "mass", label = "Mass (kg)", min = 0.1f, max = 10f, active = activeMass,
                    defaultValue = mass
                }
            },
            {
                "velocity",
                new ConfigurableProperty()
                {
                    key = "velocity", label = "Velocity (m/s)", min = 0f, max = 5f, active = activeVelocity,
                    defaultValue = velocity
                }
            },
            {
                "initialPosition",
                new ConfigurableProperty()
                {
                    key = "initialPosition", label = "Xi", min = 0f, max = 3f, active = activeInitialPosition,
                    defaultValue = initialPosition
                }
            },
            {
                "finalPosition",
                new ConfigurableProperty()
                {
                    key = "finalPosition", label = "Xf", min = 0f, max = 5f, active = activeFinalPosition,
                    defaultValue = finalPosition
                }
            },
            {
                "initialTime",
                new ConfigurableProperty()
                {
                    key = "initialTime", label = "Ti", min = 0f, max = 3f, active = activeInitialTime,
                    defaultValue = initialTime
                }
            },
            {
                "finalTime",
                new ConfigurableProperty()
                {
                    key = "finalTime", label = "Tf", min = 0f, max = 5f, active = activeFinalTime,
                    defaultValue = finalTime
                }
            },
        };
        Debug.Log("CarConfigurable initialized with properties.");
    }

    public Dictionary<string, ConfigurableProperty> GetProperties() => _properties;

    public void ApplyProperty(string key, float value)
    {
        if (_properties.TryGetValue(key, out ConfigurableProperty property))
        {
            property.defaultValue = value;
        }
        else
        {
            Debug.LogWarning($"Property {key} not found in CarConfigurable.");
        }
    }
}