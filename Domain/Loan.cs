using System;

namespace Biblioteca.Entities;

public class Loan(string id, Portfolio portfolio, User user, DateTime start_at, DateTime return_at)
{
    public string Id { get; private set; } = id;
    public Portfolio Portfolio { get; private set; } = portfolio;
    public User User { get; private set; } = user;
    public DateTime start_at { get; private set; } = start_at;
    public DateTime return_at { get; private set; } = return_at;
    public enum Condition;


}
