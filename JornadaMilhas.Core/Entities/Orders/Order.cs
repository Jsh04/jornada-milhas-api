using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Passages;

namespace JornadaMilhas.Core.Entities.Orders;

public class Order : BaseEntity
{
    private List<Passage> _passages = new();
    
    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();
    
    public Order(List<Passage>? passagesCreatedValue)
    {
        if (passagesCreatedValue is null)
            throw new ArgumentNullException(nameof(passagesCreatedValue));
        
        _passages.AddRange(passagesCreatedValue);
    }

    public decimal GetValueTotal()
    {
        //TODO
        return default;
    }
    
    public void AddPassage(Passage passage)
    {
        if (passage is null)
            throw new ArgumentNullException(nameof(passage));
        
        _passages.Add(passage);
    }
}