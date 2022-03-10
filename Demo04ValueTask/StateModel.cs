namespace Demo04ValueTask
{
    public class StateModel
    {
        public int Id { get; set; }
        // Acronym
        public string Sigla { get; set; }
        // Name
        public string Nome { get; set; }
        public Region Regiao { get; set; }
    }

    public class Region
    {
        public int Id { get; set; }
        // Acronym
        public string Sigla { get; set; }
        // Name
        public string Nome { get; set; }
    }
}
