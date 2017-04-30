using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurability
{
    public class PencilDurability
    {
        private string textOnPaper;
        private int pointDurability;
        public PencilDurability(int pointDurability = 10)
        {
            this.pointDurability = pointDurability;
            textOnPaper = "";
        }

        public void write(string textToWrite)
        {
            textOnPaper += textToWrite;
            pointDurability -= textToWrite.Replace(" ", "").Length;
            if (pointDurability < 0) pointDurability = 0;
        }

        public string checkPage()
        {
            return textOnPaper;
        }

        public int checkPointDurability()
        {
            return pointDurability;
        }
    }
}
