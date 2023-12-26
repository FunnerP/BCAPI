using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BCAPI.Models;

public partial class Worker
{
    public int IdWorker { get; set; }

    public string? Firstname { get; set; }

    public string? Surname { get; set; }

    public string? Lastname { get; set; }

    public string? Post { get; set; }

    public string? Adress { get; set; }

    public string? Number { get; set; }

    public int? IdBrigade { get; set; }
    [JsonIgnore]
    public virtual Brigade? IdBrigadeNavigation { get; set; }
}
