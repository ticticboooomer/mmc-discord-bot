using MmcBot.Service.Forum.Model;
using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Discord.Modules.Choices;

public static class ChoiceMapper
{
    public static SuperAdminAction ToSuperAdminAction(CmdSuperAdminAction action) =>
        action switch
        {
            CmdSuperAdminAction.Add => SuperAdminAction.Add,
            CmdSuperAdminAction.Remove => SuperAdminAction.Remove,
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };

    public static ForumTrackingAction ToCmdSuperAdminAction(CmdForumTrackingAction action) =>
        action switch
        {
            CmdForumTrackingAction.Track => ForumTrackingAction.Track,
            CmdForumTrackingAction.Untrack => ForumTrackingAction.Untrack,
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
}