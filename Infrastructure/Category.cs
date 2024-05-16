using System;
using System.Collections.Generic;

namespace SmartSaver_backend.Infrastructure;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<SavingGoal> SavingGoals { get; set; } = new List<SavingGoal>();
}
