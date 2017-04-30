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
        public PencilDurability()
        {
            textOnPaper = "";
        }

        public void write(string textToWrite)
        {
            textOnPaper += textToWrite;
        }

        public string checkPage()
        {
            return textOnPaper;
        }
    }
}
