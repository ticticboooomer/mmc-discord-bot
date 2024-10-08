using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MmcBot.Data.Model;

public class SuperAdmin
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("discordUserId")]
    public ulong DiscordUserId { get; set; }
    
    [BsonElement("discordUsername")]
    public string DiscordUsername { get; set; }
    
    [BsonElement("discordAvatar")]
    public ulong GuildId { get; set; }
}