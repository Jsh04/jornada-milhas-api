using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Passages;

namespace JornadaMilhas.Core.Entities.Orders;

public class Order : BaseEntity
{
    public Customer Customer { get; private set; }
    public decimal TotalValue => _passages.Sum(passage => passage.Value);
    
    private List<Passage> _passages = new();
    
    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();
    
    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddPassagesInOrder(IEnumerable<Passage> passages)
    {
        if (passages is null)
            throw new ArgumentNullException(nameof(passages));
            
        _passages.AddRange(passages);
    }
    
    public void AddPassage(Passage passage)
    {
        if (passage is null)
            throw new ArgumentNullException(nameof(passage));
        
        _passages.Add(passage);
    }
}