using RestSharp;

namespace EventosDB.MVC.Services
{
    public class SendWhatsappInvitation
    {
    }
}



public class Vvv
{
    public static async Task Main()
    {

        var url = "https://api.ultramsg.com/instance74531/messages/image";
        var client = new RestClient(url);

        var request = new RestRequest(url, Method.Post);
        request.AddHeader("content-type", "application/x-www-form-urlencoded");
        request.AddParameter("token", "gkv5jkjui2kbkmvh");
        request.AddParameter("to", "+258847198940");
        request.AddParameter("image", "https://file-example.s3-accelerate.amazonaws.com/images/test.jpg");
        request.AddParameter("caption", "image Caption");


        RestResponse response = await client.ExecuteAsync(request);
        var output = response.Content;
        Console.WriteLine(output);
    }
}
