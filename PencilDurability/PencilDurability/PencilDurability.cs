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
        private int initialPointDurability;
        private int pencilLength;
        public PencilDurability(int pointDurability = 30, int pencilLength = 30)
        {
            this.pointDurability = pointDurability;
            this.pencilLength = pencilLength;
            initialPointDurability = pointDurability;
            textOnPaper = "";
        }

        public void write(string textToWrite)
        {
            int pointDegradationValue = getPointDegradationValue(textToWrite);
            if (pointDurability > pointDegradationValue)
            {
                textOnPaper += textToWrite;
                pointDurability -= pointDegradationValue;
            }
            else
            {
                textOnPaper += getShortenedString(textToWrite, pointDurability);
                pointDurability = 0;
            }
        }

        public string checkPage()
        {
            return textOnPaper;
        }

        public int checkPointDurability()
        {
            return pointDurability;
        }

        public void sharpen()
        {
            if (pencilLength > 0)
            {
                pointDurability = initialPointDurability;
                pencilLength--;
            }
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

        private string getShortenedString(string textToWrite, int pointDurability)
        {
            string shortenedString = "";
            int remainingPointDurability = pointDurability;
            for (int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsWhiteSpace(textToWrite[i])) shortenedString += textToWrite[i];
                else if (Char.IsUpper(textToWrite[i]))
                {
                    if (remainingPointDurability >= 2)
                    {
                        remainingPointDurability -= 2;
                        shortenedString += textToWrite[i];
                    }
                    else shortenedString += " ";
                    continue;
                }
                else if (remainingPointDurability >= 1)
                {
                        remainingPointDurability -= 1;
                        shortenedString += textToWrite[i];
                }
                else shortenedString += " ";
            }
            return shortenedString;
        }
    }
}
