using FileServer.DTOs;
using FileServer.Services.Contracts;
using Renci.SshNet;

namespace FileServer.Services;
public class FtpServerService: IServerService
{
    public async Task<ConnectionResponseDto> VerifyConnectionAsync(ServerCredentialDto credential)
    {
        try
        {
            return await Task.Run(() =>
            {
                using (var client = new SftpClient(credential.Host, credential.Port, credential.Username, credential.Password))
                {
                    client.Connect();
                    bool connected = client.IsConnected;
                    client.Disconnect();

                    return new ConnectionResponseDto()
                    {
                        IsSuccess = connected,
                        Message = connected ? "SFTP connection successful." : "SFTP connection failed."
                    };
                }
            });
        }
        catch (Exception ex)
        {
            return new ConnectionResponseDto()
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}