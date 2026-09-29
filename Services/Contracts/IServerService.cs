using FileServer.DTOs;

namespace FileServer.Services.Contracts;
public interface IServerService
{
    Task<ConnectionResponseDto> VerifyConnectionAsync(ServerCredentialDto credential);
}
