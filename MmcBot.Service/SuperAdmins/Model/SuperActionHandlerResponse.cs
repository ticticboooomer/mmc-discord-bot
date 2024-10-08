namespace MmcBot.Service.SuperAdmins.Model;

public enum SuperActionHandlerResponse
{
    AddSuccess,
    RemoveSuccess,
    AddUserExists,
    RemoveUserNoExists,
    ErrUnexpected
}