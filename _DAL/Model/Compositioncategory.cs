using System;
using System.Collections.Generic;

namespace BetterPlanChallenge.Model;

public partial class Compositioncategory
{
    public string Name { get; set; } = null!;

    public string? Uuid { get; set; }

    public int Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual ICollection<Compositionsubcategory> Compositionsubcategories { get; } = new List<Compositionsubcategory>();
}
