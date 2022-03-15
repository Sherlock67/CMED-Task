namespace CMED_WEB.Models
{
    public class InteractionTypeGroup
    {
        public string sourceDisclaimer { get; set; }
        public string sourceName { get; set; }
        public List<InteractionType> interactionType { get; set; }
    }
}
