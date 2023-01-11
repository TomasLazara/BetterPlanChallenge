using System;
using System.Collections.Generic;

namespace BetterPlanChallenge.Model;

public partial class Compositionsubcategory
{
    public string Name { get; set; } = null!;

    public string? Uuid { get; set; }

    public string? Description { get; set; }

    public int Id { get; set; }

    public int? Categoryid { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual Compositioncategory? Category { get; set; }

    public virtual ICollection<Fundingcomposition> Fundingcompositions { get; } = new List<Fundingcomposition>();

    public virtual ICollection<Portfoliocomposition> Portfoliocompositions { get; } = new List<Portfoliocomposition>();
}
