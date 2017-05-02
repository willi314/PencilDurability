using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarPencilDurability
{
    public class Pencil
    {
        public const int UPPERCASE_LETTER_DEGRADATION_VALUE = 2;
        public const int LOWERCASE_LETTER_DEGRADATION_VALUE = 1;

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

        public string getShortenedString(string textToWrite, int pointDurability)
        {
            string shortenedString = "";
            int remainingPointDurability = pointDurability;
            for (int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsWhiteSpace(textToWrite[i]) || textToWrite[i].Equals('\n')) shortenedString += textToWrite[i];
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

        public int getPointDegradationValue(string textToWrite)
        {
            int degradationValue = 0;
            for (int i = 0; i < textToWrite.Length; i++)
            {
                if (Char.IsWhiteSpace(textToWrite[i]) || textToWrite[i].Equals('\n')) continue;
                if (Char.IsUpper(textToWrite[i]))
                {
                    degradationValue += Pencil.UPPERCASE_LETTER_DEGRADATION_VALUE;
                }
                else degradationValue += Pencil.LOWERCASE_LETTER_DEGRADATION_VALUE;
            }
            return degradationValue;
        }
    }
}
