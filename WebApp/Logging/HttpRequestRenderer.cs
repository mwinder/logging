using System.IO;
using System.Net.Http;
using log4net.ObjectRenderer;

namespace WebApp.Logging
{
    public class HttpRequestRenderer : IObjectRenderer
    {
        public async void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            var request = obj as HttpRequestMessage;

            if (request == null) return;

            var content = await request.GetContent();
            writer.WriteLine("Error processing request\r\n" +
                             "{0} {1}\r\n" +
                             "{2}\r\n" +
                             "{3}\r\n",
                request.Method, request.RequestUri,
                request.Headers,
                content ?? "[empty]");

        }
    }
}