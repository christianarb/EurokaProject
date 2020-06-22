namespace Netcore.Infrastructure.Crosscutting
{
    public class Constants
    {
        public enum HTTP_STATUS_CODE
        {
            OK = 200,
            CREATED = 201,
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            NOT_FOUND = 404,
            METHOD_NOT_ALLOWED = 405,
            CONTENT_TYPE_NOT_ALLOWED = 406,
            CONTENT_TYPE_WRONG = 415,
            INTERNAL_ERROR_SERVER = 500
        }

        public enum TIPO_USUARIO
        {
            CLIENTE,
            CONSULTORA
        }

        public const string TOKEN_TYPE_BEARER = "Bearer";
    }
}
