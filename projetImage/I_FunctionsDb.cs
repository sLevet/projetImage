using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace projetImage
{
    public interface I_FunctionsDb
    {
        byte[] imageToByteArray(Image imageIn);
        Image byteArrayToImage(byte[] byteArrayIn);
        int SaveImageInDb();
        void prepareLoadImageFromDb(FunctionsFile fFile);
        void loadImageFromDb(string msg);
    }
}

