using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BCAPI.Models;

public partial class Brigade
{
    public int IdBrigade { get; set; }

    public string? BrigadeName { get; set; }

    public string? BrigadeSpec { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    [JsonIgnore]
    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
