namespace SistemaBico.API.Dtos.Filter
{
    public class FilterPaginatedHomeDto : FilterPaginatedBaseDto
    {
        public string Pesquisar { get; set; }
        public string MenuId { get; set; }
    }
}
