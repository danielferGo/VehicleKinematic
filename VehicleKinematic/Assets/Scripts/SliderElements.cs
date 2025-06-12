using System.Collections.Generic;
using UnityEngine;

public class SliderElements : MonoBehaviour
{
    [SerializeField] private GameObject componentPrefab;
    public CarConfigurable configurableObject;
    private List<SliderElement> sliderElements;

    private void Start()
    {
        sliderElements = new List<SliderElement>();
        var properties = configurableObject.GetProperties();
        foreach (var property in properties)
        {
            if (property.Value.active)
            {
                var sliderComponent = Instantiate(componentPrefab, transform);
                var slider = sliderComponent.GetComponent<SliderElement>();
                slider.SetProperty(property.Value);
                sliderElements.Add(slider);
            }
        }
    }

    public void UpdateElements(CarConfigurable carConfigurable)
    {
        foreach (var slider in sliderElements)
        {
            Destroy(slider.gameObject);
            Destroy(slider);
        }

        sliderElements.Clear();
        configurableObject = carConfigurable;
        var properties = configurableObject.GetProperties();
        foreach (var property in properties)
        {
            if (property.Value.active)
            {
                var sliderComponent = Instantiate(componentPrefab, transform);
                var slider = sliderComponent.GetComponent<SliderElement>();
                slider.SetProperty(property.Value);
                sliderElements.Add(slider);
            }
        }
    }
}