using Microsoft.Extensions.Options;
using Test_1.Models;

namespace Test_1.Services;

public class PictureEditorService : IPictureEditorService
{
    private const int FakeEditDelay = 1500;
    private PluginsModel _pluginsModel;

    public PictureEditorService(IConfiguration configuration)
    {
        _pluginsModel = new PluginsModel
        {
            plugins = configuration.GetSection("plugins").Get<PluginModel[]>()
        };
    }

    public async Task<string> Edit(string imageData, List<PictureModifierData> modifiers)
    {
        // Fake edit
        await Task.Delay(FakeEditDelay);
        
        foreach (var modifier in modifiers)
        {
            var plugin = _pluginsModel.plugins.FirstOrDefault(x => x.Type == modifier.ModifierType);

            if (plugin == null) 
                continue;
            
            // do some job
            imageData += $"_mod_{plugin.Content}";
        }

        return imageData;
    }
}