using System;
using System.Collections.Generic;

namespace APIExample_day30.Models;

public partial class Companyinfo
{
    public int Cid { get; set; }

    public string Cname { get; set; } = null!;

    public virtual ICollection<Productinfo> Productinfos { get; set; } = new List<Productinfo>();
}
