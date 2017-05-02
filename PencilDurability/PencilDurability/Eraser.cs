using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurability
{
    class Eraser
    {
        private int eraserDurability;

        public Eraser(int eraserDurability = 30)
        {
            this.eraserDurability = eraserDurability;
        }

        public int EraserDurability
        {
            get
            {
                return eraserDurability;
            }

            set
            {
                eraserDurability = value;
            }
        }
    }
}
