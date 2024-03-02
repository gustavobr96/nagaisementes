namespace SistemaBico.Web.Models.Filters
{
    public class FilterPaginatedProfessionalModel : FilterPaginatedBaseModel
    {
        public string? City { get; set; }
        public List<string> Especiality { get; set; }
        public int Area { get; set; }
    }
}
