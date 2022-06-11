using Microsoft.AspNetCore.Mvc;
using Test_1.Models;
using Test_1.Services;

namespace Test_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureEditorController : ControllerBase
{
    private readonly Func<IPictureEditorService> _pictureEditorServiceFactory;

    private readonly ILogger<PictureEditorController> _logger;
    
    private const string FailedTask = "Failed task";

    public PictureEditorController(
        ILogger<PictureEditorController> logger,
        Func<IPictureEditorService> pictureEditorServiceFactory)
    {
        _logger = logger;
        _pictureEditorServiceFactory = pictureEditorServiceFactory;
    }

    [HttpGet("get-plugin-list")]
    public async Task<PluginsModel> GetPluginList()
    {
        var plugins = await _pictureEditorServiceFactory().GetPlugins();
        return plugins;
    }

    [HttpGet("edit-picture")]
    public async Task<string> EditPicture(string pictureData, List<PictureModifierData> modifiers)
    {
        try
        {
            return await _pictureEditorServiceFactory().Edit(pictureData, modifiers);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return FailedTask;
        }
    }
}