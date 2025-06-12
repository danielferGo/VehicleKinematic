using TMPro;
using UnityEngine;

public class SliderElement : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI minText;
    [SerializeField] private TextMeshProUGUI maxText;

    private ConfigurableProperty property;

    private void Start()
    {
        slider.onValueChanged.AddListener(EditProperty);
    }

    private void EditProperty(float arg0)
    {
        property.defaultValue = arg0;
        text.text = $"{property.label}: {property.defaultValue:F2}";
    }

    public void SetProperty(ConfigurableProperty configurableProperty)
    {
        property = configurableProperty;
        slider.minValue = property.min;
        slider.maxValue = property.max;
        slider.value = property.defaultValue;
        text.text = $"{property.label}: {property.defaultValue:F2}";
        minText.text = property.min.ToString("F2");
        maxText.text = property.max.ToString("F2");
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(EditProperty);
        Debug.Log("SliderElement destroyed for property: " + property.key);
    }
}