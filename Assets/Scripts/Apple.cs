using UnityEngine;

public class Apple : MonoBehaviour, IVisitable
{
    [field: SerializeField] public int RecoverableHealth { get; private set; } = 30;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}