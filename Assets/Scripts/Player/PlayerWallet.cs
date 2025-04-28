using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _coinAmount;

    private void Start()
    {
        _coinAmount = 0;
    }

    public void AddCoin()
    {
        _coinAmount++;
    }
}
