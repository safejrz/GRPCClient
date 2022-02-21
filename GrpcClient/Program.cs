using Grpc.Net.Client;
using Grpc.Core;
using GrpcClient;

try
{
    //http://localhost:5288
    //https://localhost:7288
    //http://localhost:5005
    //https://localhost:7005    

    using (var channel = GrpcChannel.ForAddress("http://localhost:5005"))
    {
        var client = new Greeter.GreeterClient(channel);
        var response = await client.SayHelloAsync(new HelloRequest { Name = "World" });
        Console.WriteLine("Greeting: " + response.Message);
    }

    Console.ReadKey();
}
catch (RpcException ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Check the service is running and the port is correct. \r\n\r\n");
    Console.WriteLine(ex.Status.Detail);
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Something was not ready: \r\n\r\n");
    Console.WriteLine(ex.Message);
}
finally
{
    Console.ForegroundColor = ConsoleColor.Gray;
}