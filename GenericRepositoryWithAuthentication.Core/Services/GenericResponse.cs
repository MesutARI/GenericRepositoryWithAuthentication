using System.Net;

namespace GenericRepositoryWithAuthentication.Core.Services
{
    public class GenericResponse<T> where T : class
    {
        #region variables
        public T Tables { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        #endregion

        #region GenericResponse
        public GenericResponse(T _tables)
        {
            this.Success = true;
            this.Tables = _tables;
            this.StatusCode = HttpStatusCode.OK;
        }

        public GenericResponse(string _message, HttpStatusCode _statusCode)
        {
            this.Success = false;
            this.Message = _message;
            this.StatusCode = _statusCode;
        }

        #endregion
    }
}
