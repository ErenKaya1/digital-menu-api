namespace DigitalMenu.Service
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public T Data { get; set; }

        public ServiceResponse(bool success, string message = default(string), string internalMessage = default(string))
        {
            this.Success = success;
            this.Message = message;
            this.InternalMessage = internalMessage;
        }
    }
}