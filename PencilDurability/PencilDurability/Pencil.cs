using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurability
{
    public class Pencil
    {
        private int pointDurability;
        private int initialPointDurability;
        private int pencilLength;

        public Pencil(int pointDurability = 30, int pencilLength = 30)
        {
            this.PointDurability = pointDurability;
            this.pencilLength = pencilLength;
            initialPointDurability = pointDurability;
        }

        public int PointDurability
        {
            get
            {
                return pointDurability;
            }

            set
            {
                pointDurability = value;
            }
        }

        public int PencilLength
        {
            get
            {
                return pencilLength;
            }
        }

        public void sharpen()
        {
            if (pencilLength > 0)
            {
                PointDurability = initialPointDurability;
                pencilLength--;
            }
        }
    }
}
