﻿namespace MvcOffice.Models
{
    public class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token[7].ToString();
        }
    }
}
