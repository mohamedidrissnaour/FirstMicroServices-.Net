using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ecom_web_app.bankaccount_service.Models;


[Table("BankAccount")]
public class BankAccount
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public DateTime createdAt { get; set; }
   public double balance  { get; set; } 
   public string currency { get; set; }
   public AccountType type { get; set; }
   

}