using GRPCClient;
using Grpc.Net.Client;
using Grpc.Core;

//localhost:7288
//localhost:7051
using (var channel = GrpcChannel.ForAddress("https://localhost:7288"))
{
    try
    {
        var client = new Greeter.GreeterClient(channel);
        var response = await client.SayHelloAsync(new HelloRequest { Name = "World" });     
        Console.WriteLine("Greeting: " + response.Message);
    }
    catch (RpcException ex)
    {
        Console.WriteLine("Check the service is running and the port is correct." + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Something was not ready: " + ex.Message);
    }
    Console.ReadKey();
}



