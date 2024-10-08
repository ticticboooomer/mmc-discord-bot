using Discord.Interactions;

namespace MmcBot.Discord.Modules.Choices;

public enum CmdSuperAdminAction
{
    [ChoiceDisplay("add")]
    Add,
    [ChoiceDisplay("rm")]
    Remove
}