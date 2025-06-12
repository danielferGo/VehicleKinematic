using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FormulaDisplay : MonoBehaviour
{
    public TextMeshProUGUI formulaText;
    public TextMeshProUGUI descriptionText;

    public void SetFormula(Formula formula, Dictionary<string, float> liveValues = null)
    {
        string equation = formula.rawEquation;

        // If live values are provided, replace variables
        if (liveValues != null)
        {
            foreach (var kvp in liveValues)
            {
                equation = equation.Replace(kvp.Key, $"{kvp.Key}({kvp.Value:F2})");
            }
        }

        formulaText.text = equation;
        descriptionText.text = formula.description;
    }

    public void SetFormula(string equation)
    {
        formulaText.text = equation;
    }
}