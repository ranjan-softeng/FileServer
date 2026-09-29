using FileServer.DTOs;
using FileServer.Services;
using FileServer.Services.Contracts;
class Program
{
    static async Task Main(string[] args)
    {
        ServerCredentialDto credential = new ServerCredentialDto();
        Console.WriteLine("--- Enter Your File Server Crendential ---");

        Console.Write("Enter Server Type: ");
        credential.ServerType = Console.ReadLine() ?? "";

        Console.Write("Enter Host: ");
        credential.Host = Console.ReadLine() ?? "";

        Console.Write("Enter Port: ");
        string port = Console.ReadLine() ?? "";
        int.TryParse(port, out int parsedPort);
        credential.Port = parsedPort;

        Console.Write("Enter Username: ");
        credential.Username = Console.ReadLine() ?? "";

        Console.Write("Enter Password: ");
        credential.Password = Console.ReadLine() ?? "";

        Console.WriteLine("\n--- Server Credential ---");
        Console.WriteLine("Server Type : " + credential.ServerType);
        Console.WriteLine("Host        : " + credential.Host);
        Console.WriteLine("Port        : " + credential.Port);
        Console.WriteLine("Username    : " + credential.Username);
        Console.WriteLine("Password    : " + credential.Password);

        IServerService fileServer = new FtpServerService();
        ConnectionResponseDto res =  await fileServer.VerifyConnectionAsync(credential);

        if(res.IsSuccess)
        {
            Console.WriteLine("\n--- Credential is verfied ---");
            Console.WriteLine(res.Message);
        }
        else
        {
            Console.WriteLine("\n--- Credential is not verfied ---");
            Console.WriteLine(res.Message);
        }

    }
}