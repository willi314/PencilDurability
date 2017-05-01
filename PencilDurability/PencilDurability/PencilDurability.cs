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
            pointDurability -= getPointDegradationValue(textToWrite);
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

        private int getPointDegradationValue(string textToWrite)
        {
            textToWrite = textToWrite.Replace(" ", "");
            int degradationValue = 0;
            for(int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsUpper(textToWrite[i]))
                {
                    degradationValue += 2;
                }
                else degradationValue++;
            }
            return degradationValue;
        }
    }
}
