using Grpc.Net.Client;
using microservice_map_info.Protos;

static async Task Main(string[] args)
{
    var channel = GrpcChannel.ForAddress(new Uri("https://localhost:7143"));
    var client = new DistanceInfo.DistanceInfoClient(channel);
    var response = await
client.GetDistanceAsync(new Cities
{ OriginCity = "Topeka,KS", DestinationCity = "Los Angeles,CA" });
    Console.WriteLine("EXAMPLE\n");
    Console.ReadKey();
}
