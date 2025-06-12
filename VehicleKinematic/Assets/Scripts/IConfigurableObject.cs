using System.Collections.Generic;

public interface IConfigurableObject
{
    string GetDisplayName();
    Dictionary<string, ConfigurableProperty> GetProperties(); 
    void ApplyProperty(string key, float value);
}