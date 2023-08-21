using System;
using System.Collections.Generic;

namespace APIExample_day30.Models;

public partial class Productinfo
{
    public int Pid { get; set; }

    public string Pname { get; set; } = null!;

    public double? Pprice { get; set; }

    public DateTime? Pmdate { get; set; }

    public int? Cid { get; set; }

    public virtual Companyinfo? CidNavigation { get; set; }
}
