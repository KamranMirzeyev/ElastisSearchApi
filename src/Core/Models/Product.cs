using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Product : BaseEntity
    {
        public const string SearchIndex = "products";
        public string  ProductName { get; set; }

        public int Quantity { get; set; }
        public string Photo { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }



        static string RemoveReservedUrlCharacters(string text)
        {
            var reservedCharacters = new List<string>() { "!", "#", "$", "&", "'", "(", ")", "*", ",", "/", ":", ";", "=", "?", "@", "[", "]", "\"", "%", ".", "<", ">", "\\", "^", "_", "'", "{", "}", "|", "~", "`", "+" };

            foreach (var chr in reservedCharacters)
            {
                text = text.Replace(chr, "");
            }

            return text;
        }
    }
}