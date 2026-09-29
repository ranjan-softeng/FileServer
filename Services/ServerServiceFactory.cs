using FileServer.Services;
using FileServer.Services.Contracts;
public static class ServerServiceFactory
{
    public static IServerService GetServerService(string serverType)
    {
        switch (serverType.ToUpper())
        {
            case "SFTP":
                return new SftpServerService();

            case "FTP":
                return new FtpServerService();

            case "FTPS":
                return new FtpsServerService();

            default:
                throw new ArgumentException("Unsupported server type: " + serverType);
        }
    }
}