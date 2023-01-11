using System;
using System.Collections.Generic;

namespace BetterPlanChallenge.Model;

public partial class Risklevel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual ICollection<Goal> Goals { get; } = new List<Goal>();

    public virtual ICollection<Portfolio> Portfolios { get; } = new List<Portfolio>();
}
