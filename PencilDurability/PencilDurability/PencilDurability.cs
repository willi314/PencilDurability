﻿using System;
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
                }
                else
                {
                    if (remainingPointDurability >= 1)
                    {
                        remainingPointDurability -= 1;
                        shortenedString += textToWrite[i];
                    }
                    else shortenedString += " ";
                }
            }
            return shortenedString;
        }
    }
}
