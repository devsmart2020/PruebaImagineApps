namespace PruebaTecnica.Api.Src.Core.Business.Wrappers
{
    public sealed class ResponseDto<T>
    {
        public ResponseDto()
        {

        }

        public ResponseDto(T data, string message)
        {
            Succeed = true;
            Message = message;
            Data = data;
        }
        public ResponseDto(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
