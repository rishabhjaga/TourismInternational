using System;
using System.Collections.Generic;

namespace TourismInternational.Models.EF;

public partial class TouristLocation
{
    public int PlaceId { get; set; }

    public string? LocationName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? LocationImage { get; set; }
}
