namespace Football.Middlewares
{
    /// <summary>
    /// Classe padrão de erros
    /// </summary>
    public class GlobalExceptionResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public GlobalExceptionResult(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Exception message completa
        /// </summary>
        public string ExceptionMessage { get; private set; }

        /// <summary>
        /// Pilha da exception
        /// </summary>
        public string ExceptionStackTrace { get; private set; }

        /// <summary>
        /// Detalhes
        /// </summary>
        public string ExceptionDetail { get; private set; }

        /// <summary>
        /// Dados em DEV
        /// </summary>
        /// <param name="exceptionMessage"></param>
        /// <param name="exceptionStackTrace"></param>
        /// <param name="exceptionDetail"></param>
        public void SetDevelopmentDetails(string exceptionMessage, string exceptionStackTrace, string exceptionDetail)
        {
            this.ExceptionMessage = exceptionMessage;
            this.ExceptionStackTrace = exceptionStackTrace;
            this.ExceptionDetail = exceptionDetail;
        }
    }
}
