using MmcBot.Service.SuperAdmins.Model;

namespace MmcBot.Discord.Modules.Choices;

public static class ChoiceConverter
{
    public static SuperAdminAction ToSuperAdminAction(CmdSuperAdminAction action) =>
        action switch
        {
            CmdSuperAdminAction.Add => SuperAdminAction.Add,
            CmdSuperAdminAction.Remove => SuperAdminAction.Remove,
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
}