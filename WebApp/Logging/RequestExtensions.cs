using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Logging
{
    public static class RequestExtensions
    {
        public static async Task<string> GetContent(this HttpRequestMessage request)
        {
            var content = await request.Content.ReadAsStreamAsync();
            if (content.Length == 0)
                return null;
            if (content.CanSeek)
                content.Position = 0;
            return await request.Content.ReadAsStringAsync();
        }
    }
}