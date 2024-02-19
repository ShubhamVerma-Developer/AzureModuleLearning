using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeFunction.Services
{
    internal interface IImageResizer
    {
        void Resize(Stream input, Stream output);
    }
}
