using System;

namespace FitHealth.Domain.Common;

public abstract class BaseEntity
{
    // Sử dụng tính năng sinh UUID v7 nguyên bản của .NET
        public Guid Id { get; set; } = Guid.CreateVersion7();
}   