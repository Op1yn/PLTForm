using UnityEngine;

public class Apple : MonoBehaviour
{
    [field: SerializeField] public int RecoverableHealth { get; private set; } = 30;

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
