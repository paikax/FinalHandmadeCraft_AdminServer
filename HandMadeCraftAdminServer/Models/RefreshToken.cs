﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HandMadeCraftAdminServer.Models
{
    public class RefreshToken
    {
        public RefreshToken()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        [Key]
        [JsonIgnore]
        public string Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedBy { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        
        public bool IsRevoked => Revoked != null;
        
        public string UserId { get; set; }
        public User.User User { get; set; }
    }
}