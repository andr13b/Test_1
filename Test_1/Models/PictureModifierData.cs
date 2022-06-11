namespace Test_1.Models;

public class PictureModifierData
{
    public PictureModifierData(string modifierType, Dictionary<string, string> modifierParams)
    {
        ModifierType = modifierType;
        ModifierParams = modifierParams;
    }
    
    public string ModifierType { get; }
    public Dictionary<string, string> ModifierParams { get; }
}