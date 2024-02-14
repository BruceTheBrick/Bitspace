namespace Bitspace.Core;

public interface IAlertService
{
    public Task ShowSnackbar(string message);
    public Task Toast(string message);
    public Task Toast(string message, int milliseconds);
}