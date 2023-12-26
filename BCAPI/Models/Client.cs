using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BCAPI.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Firstname { get; set; }

    public string? Surname { get; set; }

    public string? Lastname { get; set; }

    public string? Adress { get; set; }

    public string? Number { get; set; }

    public int? Balance { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
