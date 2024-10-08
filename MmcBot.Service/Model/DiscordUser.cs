namespace MmcBot.Service.Model;

public class DiscordUser
{
    public ulong UserId { get; set; }
    public string Username { get; set; }
    public string Discriminator { get; set; }
}