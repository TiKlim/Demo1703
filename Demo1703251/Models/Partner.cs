using System;
using System.Collections.Generic;

namespace Demo1703251.Models;

public partial class Partner
{
    public int PartnersId { get; set; }

    public string? PartnersName { get; set; }

    public string? PartnersDirectorName { get; set; }

    public string? PartnersAdress { get; set; }

    public string? PartnersPhone { get; set; }

    public string? PartnersEmail { get; set; }

    public virtual ICollection<ProductsPartner> ProductsPartners { get; set; } = new List<ProductsPartner>();
}
