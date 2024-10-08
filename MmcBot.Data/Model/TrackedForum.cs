using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MmcBot.Data.Model;

public class TrackedForum
{
    [BsonId] 
    public ObjectId Id { get; set; }
    
    [BsonElement("channelId")]
    public ulong ChannelId { get; set; }
    
    [BsonElement("channelName")]
    public string ChannelName { get; set; }
    
    [BsonElement("guildId")]
    public ulong GuildId { get; set; }
}