using System;
using System.Collections.Generic;

namespace BetterPlanChallenge.Model;

public partial class Financialentity
{
    public string? Logo { get; set; }

    public string Title { get; set; } = null!;

    public string? Uuid { get; set; }

    public int Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public string? Description { get; set; }

    public int? Defaultcurrencyid { get; set; }

    public virtual Currency? Defaultcurrency { get; set; }

    public virtual ICollection<Funding> Fundings { get; } = new List<Funding>();

    public virtual ICollection<Goal> Goals { get; } = new List<Goal>();

    public virtual ICollection<Goaltransaction> Goaltransactions { get; } = new List<Goaltransaction>();

    public virtual ICollection<Investmentstrategy> Investmentstrategies { get; } = new List<Investmentstrategy>();

    public virtual ICollection<Investmentstrategytype> Investmentstrategytypes { get; } = new List<Investmentstrategytype>();

    public virtual ICollection<Portfolio> Portfolios { get; } = new List<Portfolio>();
}
