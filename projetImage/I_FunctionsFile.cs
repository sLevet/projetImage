using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace projetImage
{
    public interface I_FunctionsFile
    {
        void LoadImageFromFile();
        void SaveImage();
        void LoadImageFromDb(Image img);
        String CheckName(String name);

    }
}
