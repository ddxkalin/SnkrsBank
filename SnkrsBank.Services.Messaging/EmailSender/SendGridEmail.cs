﻿namespace SnkrsBank.Services.Messaging.EmailSender
{
    using Newtonsoft.Json;

    public class SendGridEmail
    {
        public SendGridEmail()
        {
        }

        public SendGridEmail(string email, string name = null)
        {
            this.Email = email;
            this.Name = name;
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}