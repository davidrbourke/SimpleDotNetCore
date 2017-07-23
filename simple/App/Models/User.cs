using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Simple.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int GetAgeInDays()
        {
            if (!DateOfBirth.HasValue)
                return 0;

            return (DateTime.Now - DateOfBirth.Value).Days;
        }

        public override string ToString()
        {
            return $"{Id}, {Firstname}, {Lastname}, {DateOfBirth}";
        }
    }
}