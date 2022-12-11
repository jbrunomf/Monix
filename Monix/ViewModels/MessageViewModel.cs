using Newtonsoft.Json;

namespace Monix.ViewModels;

public class MessageViewModel
{
    public enum EMessageType
    {
        Information,
        Error,
        Warning,
    }

    public EMessageType Type { get; set; }
    public string Text { get; set; }

    public MessageViewModel(string message, EMessageType type = EMessageType.Information)
    {
        Type = type;
        Text = message;
    }

    public static string Serialize(string message, EMessageType type = EMessageType.Information)
    {
        var messageViewModel = new MessageViewModel(message, type);
        return JsonConvert.SerializeObject(messageViewModel);
    }

    public static MessageViewModel Deserialize(string mensagemString)
    {
        return JsonConvert.DeserializeObject<MessageViewModel>(mensagemString);
    }
}