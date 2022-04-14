namespace Example.Application._Common.Models.Response
{
    public class GetByIdResponse<TDto>
        where TDto : class
    {
        public TDto Data { get; set; }
    }
}
