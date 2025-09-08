using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Seller
{
    public Seller(string id, string name)
    {
        Id = id;
        Name = name;
    }
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
