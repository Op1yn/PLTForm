using UnityEngine;

public class Collector : MonoBehaviour, IVisitor
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IVisitable element;

        if (other.gameObject.TryGetComponent<IVisitable>(out element))
        {
            element?.Accept(this);
            other.gameObject.SetActive(false);
        }
    }

    public void Visit(Coin coin)
    {
        _playerWallet.AddCoin();
    }

    public void Visit(Apple apple)
    {
        _health.ReplenishHealth(apple.RecoverableHealth);
    }
}
