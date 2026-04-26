using FitHealth.Domain.Common;
using System;

namespace FitHealth.Domain.Entities
{
    public class ChatMessage : BaseEntity
    {
        public Guid SessionId { get; set; }
        public string Role { get; set; } = string.Empty; // "User" hoặc "AI"
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ChatSession Session { get; set; } = null!;
    }
}