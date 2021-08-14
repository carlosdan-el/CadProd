using System;

namespace Domain.Interfaces
{
    public interface IDatabaseEntity
    {
        string Id { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
    }
}