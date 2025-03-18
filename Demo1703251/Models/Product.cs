using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo1703251.Models;

public partial class Product
{
    public string ProductsArticul { get; set; } = null!;

    public string? ProductsName { get; set; }

    public int? ProductsType { get; set; }

    public decimal? ProductsMinCostForPartner { get; set; }

    public string Background
    {
        get
        {
            int iiii = MainCount();


            if (iiii < 10000)
            {
                return "Red";
            }
            else if (iiii >= 10000 && iiii < 60000)
            {
                return "Orange";
            }
            else if (iiii > 60000)
            {
                return "Green";
            }
            return "White";
        }
    }

    private int MainCount()
    {
        int tyu = 0;
        foreach (var history in ProductsPartners)
        {
            tyu += (int)history.ProductCount;
        }
        return tyu;
    }

    public virtual ICollection<ProductsPartner> ProductsPartners { get; set; } = new List<ProductsPartner>();

    public virtual ProductsType? ProductsTypeNavigation { get; set; }
}
