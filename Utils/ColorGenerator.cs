using System;

namespace UIConfiguration.Utils
{
    public class ColorGenerator
    {
        private static Random rand = new Random();
        public string getColor(char c)
        {
            string targetColor = (c >= 'A' && c <= 'E') ? "#9932CC" :
                                 (c >= 'F' && c <= 'J') ? "#20B2AA" :
                                 (c >= 'K' && c <= 'O') ? "#FFD700" :
                                 (c >= 'P' && c <= 'T') ? "#FFD700" :
                                 (c >= 'I' && c <= 'L') ? "#FFD700" : "#FFD700";

            return targetColor;
        }
    }
}