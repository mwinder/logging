using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Helpers
{
    public static class RequestExtensions
    {
        public static async Task<string> GetContent(this HttpRequestMessage request)
        {
            var content = await request.Content.ReadAsStreamAsync();
            if (content.CanSeek)
                content.Position = 0;
            return await request.Content.ReadAsStringAsync();
        }
    }
}