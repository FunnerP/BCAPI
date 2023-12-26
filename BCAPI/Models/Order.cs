using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BCAPI.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdClient { get; set; }

    public int? IdBrigade { get; set; }

    public DateTime? Date { get; set; }

    public int? Cost { get; set; }
    [JsonIgnore]
    public virtual Brigade? IdBrigadeNavigation { get; set; }
    [JsonIgnore]
    public virtual Client? IdClientNavigation { get; set; }
}
