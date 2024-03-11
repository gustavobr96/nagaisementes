namespace SistemaBico.API.Dtos.Filter
{
    public class PaginacaoRazorDto : FilterPaginatedBaseDto
    {
        public int CountRegister { get; set; }
        public int PagesSize { get; set; }
    }
}
