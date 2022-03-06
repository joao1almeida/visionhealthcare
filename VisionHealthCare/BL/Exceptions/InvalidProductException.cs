using System;

namespace BL.Exceptions
{
    public class InvalidProductException : Exception
    { 
        public InvalidProductException(string productInfo) : base(String.Format("Invalid Product: {0}", productInfo))
        {

        }
    }
}
