using HWW8WithEF.Entities;
using System.Collections.Generic;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Food> Menu { get; set; } = [];
}