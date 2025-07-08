using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovellGame.Models;

internal sealed class FlagAction : Action
{
    [JsonPropertyName("flag")]
    public string FlagName { get; set; } = "";
    [JsonPropertyName("set")]
    public bool Set { get; set; } = true;
}

