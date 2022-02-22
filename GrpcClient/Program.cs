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
        
        var rowid = new RowIdRequest()
        {
            Id = 1
        };

        var response2 = await client.GetRowAsync(new RowIdRequest { Id = 1 });
        Console.WriteLine("DataTableResponse: ");
        foreach (var s in response2.Value)
        {
            Console.WriteLine(s);
        }
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