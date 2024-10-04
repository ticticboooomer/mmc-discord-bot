using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MmcBot.Data.Model;

public class CommandMacro
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("command")]
    public string Command { get; set; }
    
    [BsonElement("response")]
    public string Response { get; set; }
}