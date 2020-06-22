using System;


namespace Netcore.Infrastructure.Crosscutting.ExceptionsTypes
{
    public class NotFoundException : Exception
    {
        private string _errorMessage;
        public NotFoundException(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public NotFoundException()
        {
            _errorMessage = "";
        }

        public override string Message
        {
            get
            {
                return _errorMessage;
            }
        }
    }
}
