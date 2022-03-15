namespace CMED_WEB.Models
{
    public class AllServices
    {
        public SourceConceptItem sourceConcept { get; set; }

        public Root root { get; set; }
        
        public MinConceptItem minConcept { get; set; }
        
        public InteractionTypeGroup typeGroup { get; set; }
        
        public InteractionType type { get; set; }

        public InteractionPair interactionPair { get; set; }

        public InteractionConcept Concept { get; set; }
       
       
    }
}
