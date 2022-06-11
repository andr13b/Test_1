using Test_1.Models;

namespace Test_1.Services;

public interface IPictureEditorService
{
    Task<string> Edit(string imageData, List<PictureModifierData> modifiers);
    Task<PluginsModel> GetPlugins();
}