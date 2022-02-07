using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tools.FileStreamer.Model
{
    public class FileStreamModel
    {
        public FileInfo FileInfo { get; set; }
        public long Start { get; set; }
        public long End { get; set; }

    }
}
