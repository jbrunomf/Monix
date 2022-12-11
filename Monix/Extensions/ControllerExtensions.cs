using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Monix.ViewModels;

namespace Monix.Extensions;

public static class ControllerExtensions
{
    public static void ShowMessage(this Controller @this, string text, bool error = false)
    {
        @this.TempData["message"] = MessageViewModel.Serialize(text,
            error ? MessageViewModel.EMessageType.Error : MessageViewModel.EMessageType.Information);
    }
}