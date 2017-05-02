﻿using System;
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
        private string textOnPaper;
        private int eraserDurability;

        public PencilDurability(int pointDurability = 30, int pencilLength = 30, int eraserDurability = 30)
        {
            pencil = new Pencil(pointDurability, pencilLength);
            this.eraserDurability = eraserDurability;
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
            return eraserDurability;
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
