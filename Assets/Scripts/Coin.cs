using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IVisitor visitor;

        if (other.gameObject.TryGetComponent<IVisitor>(out visitor))
        {
            Accept(visitor);
        }
    }

    private void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
