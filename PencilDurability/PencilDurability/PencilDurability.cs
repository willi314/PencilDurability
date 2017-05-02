using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurability
{
    public class PencilDurability
    {
        const int UPPERCASE_LETTER_DEGRADATION_VALUE = 2;
        const int LOWERCASE_LETTER_DEGRADATION_VALUE = 1;

        private string textOnPaper;
        private int pointDurability;
        private int initialPointDurability;
        private int pencilLength;
        private int eraserDurability;

        public PencilDurability(int pointDurability = 30, int pencilLength = 30, int eraserDurability = 30)
        {
            this.pointDurability = pointDurability;
            this.pencilLength = pencilLength;
            this.eraserDurability = eraserDurability;
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

        public int checkEraserDurability()
        {
            return eraserDurability;
        }

        public void sharpen()
        {
            if (pencilLength > 0)
            {
                pointDurability = initialPointDurability;
                pencilLength--;
            }
        }

        public void erase(string textToErase)
        {
            int eraseStartIndex = textOnPaper.LastIndexOf(textToErase);
            StringBuilder textOnPaperStringBuilder = new StringBuilder(textOnPaper);
            for(int i = eraseStartIndex + textToErase.Length - 1; i >= eraseStartIndex; i--)
            {
                if (eraserDurability <= 0) break;
                textOnPaperStringBuilder[i] = ' ';
                eraserDurability--;
            }
            textOnPaper = textOnPaperStringBuilder.ToString();
        }

        private int getPointDegradationValue(string textToWrite)
        {
            textToWrite = textToWrite.Replace(" ", "");
            int degradationValue = 0;
            for(int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsUpper(textToWrite[i]))
                {
                    degradationValue += UPPERCASE_LETTER_DEGRADATION_VALUE;
                }
                else degradationValue += LOWERCASE_LETTER_DEGRADATION_VALUE;
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
                    if (remainingPointDurability >= UPPERCASE_LETTER_DEGRADATION_VALUE)
                    {
                        remainingPointDurability -= UPPERCASE_LETTER_DEGRADATION_VALUE;
                        shortenedString += textToWrite[i];
                    }
                    else shortenedString += " ";
                    continue;
                }
                else if (remainingPointDurability >= LOWERCASE_LETTER_DEGRADATION_VALUE)
                {
                        remainingPointDurability -= LOWERCASE_LETTER_DEGRADATION_VALUE;
                        shortenedString += textToWrite[i];
                }
                else shortenedString += " ";
            }
            return shortenedString;
        }
    }
}
