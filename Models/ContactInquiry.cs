﻿namespace RoarIndustriesApi.Models
{
    public class ContactInquiry
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Company { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string ServiceInterest { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
