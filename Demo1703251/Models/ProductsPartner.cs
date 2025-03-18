using System;
using System.Collections.Generic;

namespace Demo1703251.Models;

public partial class ProductsPartner
{
    public int ProductsPartnersId { get; set; }

    public string Products { get; set; } = null!;

    public int Partners { get; set; }

    public long? ProductCount { get; set; }

    public DateOnly? DateOfRealization { get; set; }

    public virtual Partner PartnersNavigation { get; set; } = null!;

    public virtual Product ProductsNavigation { get; set; } = null!;
}
