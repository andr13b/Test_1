using Test_1.Models;

namespace Test_1.Services;

public class PictureEditorService : IPictureEditorService
{
    private const int FakeEditDelay = 1500;

    public PictureEditorService()
    {
    }

    public async Task<string> Edit(string imageData, List<PictureModifierData> modifiers)
    {
        // Fake edit
        await Task.Delay(FakeEditDelay);
        foreach (var modifier in modifiers)
        {
            // do some job
            imageData += "_mod";
        }

        return imageData;
    }
}