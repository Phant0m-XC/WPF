using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace DZ2_3
{
    class PictureBlock
    {
        private CroppedBitmap imageBit;
        private int number;
        public PictureBlock(CroppedBitmap imageBit, int number)
        {
            this.imageBit = imageBit;
            this.number = number;
        }
        public CroppedBitmap getCroppedBitmap()
        {
            return imageBit;
        }
        public int getNumber()
        {
            return number;
        }
    }
}
