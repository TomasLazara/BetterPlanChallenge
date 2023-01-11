using _DAL;
using System;
using System.Collections.Generic;

namespace BetterPlanChallenge.Model;

public partial class User : EntityMaster
{
    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Id { get; set; }

    public int? Advisorid { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public int? Currencyid { get; set; }

    public virtual User? Advisor { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<Goal> Goals { get; } = new List<Goal>();

    public virtual ICollection<Goaltransactionfunding> Goaltransactionfundings { get; } = new List<Goaltransactionfunding>();

    public virtual ICollection<Goaltransaction> Goaltransactions { get; } = new List<Goaltransaction>();

    public virtual ICollection<User> InverseAdvisor { get; } = new List<User>();
}
