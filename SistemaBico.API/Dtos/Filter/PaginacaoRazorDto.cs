namespace SistemaBico.API.Dtos.Filter
{
    public class PaginacaoRazorDto
    {
        public int Page { get; set; } = 1;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 12;

        public int CountRegister { get; set; }
        public int PagesSize { get; set; }
    }
}
