using Infrastructure.Tools.FileStreamer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tools.FileStreamer
{
    public class FileStreamerPlay:FileStreamModel
    {
        public async Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            try
            {
                var buffer = new byte[65536];
                using (var video = FileInfo.OpenRead())
                {
                    if (End == -1)
                    {
                        End = video.Length;
                    }
                    var position = Start;
                    var bytesLeft = End - Start + 1;
                    video.Position = Start;
                    while (position <= End)
                    {
                        var bytesRead = video.Read(buffer, 0, (int)Math.Min(bytesLeft, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        position += bytesRead;
                        bytesLeft = End - position + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                // fail silently
            }
            finally
            {
                outputStream.Close();
            }
        }

    }
}
