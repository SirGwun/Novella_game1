using System.Text.Json.Serialization;

namespace NovellGame.Models;
internal sealed class FlagCondition : Condition
{
    [JsonPropertyName("flagName")]
    public string FlagName {get; set; } = "";
}