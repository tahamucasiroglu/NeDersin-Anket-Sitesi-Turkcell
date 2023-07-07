namespace NeDersin.DTOs.Concrete.Response.Models.HateoasModels
{
    public sealed record class LinkModel
    {
        public string? Href { get; set; }
        public string? Rel { get; set; }
        public string? Method { get; set; }

        public LinkModel(string? href = null, string? rel = null, string? method = null)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }

        public static LinkModel Create(string? href = null, string? rel = null, string? method = null) => new LinkModel(href, rel, method);
    }
}
