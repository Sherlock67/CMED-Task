namespace CMED_WEB.Models
{
    public class InteractionType
    {
        public string comment { get; set; }
        public MinConceptItem minConceptItem { get; set; }
        public List<InteractionPair> interactionPair { get; set; }
    }
}
