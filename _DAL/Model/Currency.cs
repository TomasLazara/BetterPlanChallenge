using System;
using System.Collections.Generic;

namespace BetterPlanChallenge.Model;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public string Uuid { get; set; } = null!;

    public string? Yahoomnemonic { get; set; }

    public string? Currencycode { get; set; }

    public string? Digitsinfo { get; set; }

    public string? Display { get; set; }

    public string? Locale { get; set; }

    public string? Serverformatnumber { get; set; }

    public virtual ICollection<Currencyindicator> CurrencyindicatorDestinationcurrencies { get; } = new List<Currencyindicator>();

    public virtual ICollection<Currencyindicator> CurrencyindicatorSourcecurrencies { get; } = new List<Currencyindicator>();

    public virtual ICollection<Financialentity> Financialentities { get; } = new List<Financialentity>();

    public virtual ICollection<Funding> Fundings { get; } = new List<Funding>();

    public virtual ICollection<Goal> GoalCurrencies { get; } = new List<Goal>();

    public virtual ICollection<Goal> GoalDisplaycurrencies { get; } = new List<Goal>();

    public virtual ICollection<Goaltransaction> Goaltransactions { get; } = new List<Goaltransaction>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
