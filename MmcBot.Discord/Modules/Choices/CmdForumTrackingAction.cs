using Discord.Interactions;

namespace MmcBot.Discord.Modules.Choices;

public enum CmdForumTrackingAction
{
    [ChoiceDisplay("track")]
    Track,
    [ChoiceDisplay("untrack")]
    Untrack
}