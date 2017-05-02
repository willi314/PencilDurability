using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillarPencilDurability;

namespace PillarPencilDurability
{
    public class PencilDurability
    {
        const int UPPERCASE_LETTER_DEGRADATION_VALUE = 2;
        const int LOWERCASE_LETTER_DEGRADATION_VALUE = 1;

        private Pencil pencil;
        private Eraser eraser;
        private string textOnPaper;

        public PencilDurability(int pointDurability = 30, int pencilLength = 30, int eraserDurability = 30)
        {
            pencil = new Pencil(pointDurability, pencilLength);
            eraser = new Eraser(eraserDurability);
            textOnPaper = "";
        }

        public void write(string textToWrite)
        {
            int pointDegradationValue = getPointDegradationValue(textToWrite);
            if (pencil.PointDurability > pointDegradationValue)
            {
                textOnPaper += textToWrite;
                pencil.PointDurability -= pointDegradationValue;
            }
            else
            {
                textOnPaper += getShortenedString(textToWrite, pencil.PointDurability);
                pencil.PointDurability = 0;
            }
        }

        public void writeAtIndex(int startIndex, string textToWrite)
        {
            int pointDegradationValue = getPointDegradationValue(textToWrite);
            if (pencil.PointDurability > pointDegradationValue)
            {
                insertText(startIndex, textToWrite);
                pencil.PointDurability -= pointDegradationValue;
            }
        }

        public string checkPage()
        {
            return textOnPaper;
        }

        public int checkPointDurability()
        {
            return pencil.PointDurability;
        }

        public int checkEraserDurability()
        {
            return eraser.EraserDurability;
        }

        public void sharpen()
        {
            pencil.sharpen();
        }

        public void erase(string textToErase)
        {
            int eraseStartIndex = textOnPaper.LastIndexOf(textToErase);
            StringBuilder textOnPaperStringBuilder = new StringBuilder(textOnPaper);
            for(int i = eraseStartIndex + textToErase.Length - 1; i >= eraseStartIndex; i--)
            {
                if (eraser.EraserDurability <= 0) break;
                textOnPaperStringBuilder[i] = ' ';
                eraser.EraserDurability--;
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

        private void insertText(int startIndex, string textToWrite)
        {
            StringBuilder textOnPaperStringBuilder = new StringBuilder(textOnPaper);
            for(int i = startIndex; i < startIndex + textToWrite.Length; i++)
            {
                if(i >= textOnPaper.Length)
                {
                    textOnPaperStringBuilder.Append(textToWrite[i - startIndex]);
                }
                else if (textOnPaper[i].Equals(textToWrite[i - startIndex]) || Char.IsWhiteSpace(textOnPaper[i]) || i >= textOnPaper.Length)
                {
                    textOnPaperStringBuilder[i] = textToWrite[i - startIndex];
                }
                else if (char.IsWhiteSpace(textToWrite[i - startIndex])) continue;
            }

            textOnPaper = textOnPaperStringBuilder.ToString();
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
