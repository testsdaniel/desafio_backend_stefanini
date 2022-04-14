namespace Example.Application._Common.Models.Response
{
    public class GetAllResponse<TDto>
        where TDto : class
    {
        public List<TDto> List { get; set; }
    }
}
