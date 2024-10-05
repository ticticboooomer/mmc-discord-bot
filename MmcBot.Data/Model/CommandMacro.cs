using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MmcBot.Data.Model;

public class CommandMacro
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("command")]
    [StringLength(100)]
    public required string Command { get; set; }
    
    [BsonElement("response")]
    [StringLength(5000)]
    public required string Response { get; set; }
}