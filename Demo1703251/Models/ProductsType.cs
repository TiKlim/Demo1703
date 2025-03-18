using System;
using System.Collections.Generic;

namespace Demo1703251.Models;

public partial class ProductsType
{
    public int ProductsTypeId { get; set; }

    public string? ProductsTypeName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
