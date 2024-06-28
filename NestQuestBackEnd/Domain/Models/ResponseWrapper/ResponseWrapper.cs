namespace NestQuestBackEnd.Domain.Models.ResponseWrapper
{
    public class ResponseWrapper<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

    }
}
