namespace Coords.App.Commands.CreateCoord
{
    public record CreateCoordsCommandResult(bool IsValid, bool IsSent, string? ErrorMessage = null);
}
