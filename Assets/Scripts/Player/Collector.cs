using UnityEngine;

public class Collector : MonoBehaviour, IVisitor
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Health _health;

    public void Visit(Coin coin)
    {
        _playerWallet.AddCoin();
        coin.gameObject.SetActive(false);
    }

    public void Visit(Apple apple)
    {
        _health.ReplenishHealth(apple.RecoverableHealth);
        apple.gameObject.SetActive(false);
    }
}
