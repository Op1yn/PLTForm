using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out _))
        {
            other.gameObject.SetActive(false);
            _playerWallet.AddCoin();
        }
    }
}
