using Discord;
using MmcBot.Service.Model;

namespace MmcBot.Discord.Extensions;

public static class DiscordModelExtensions
{
    public static DiscordUser ToDiscordUser(this IUser user)
    {
        return new DiscordUser
        {
            UserId = user.Id,
            Username = user.Username,
            Discriminator = user.Discriminator
        };
    }
}