namespace SistemaBico.API.Dtos.Filter
{
    public class FilterPaginatedBaseDto
    {
        public int Page { get; set; } = 1;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
