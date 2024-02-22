
namespace JornadaMilhas.Core.Indices
{
    public abstract class ElasticBaseIndex
    {
        
        public string Id { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}
