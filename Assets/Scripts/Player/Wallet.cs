using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinsCount = 0;

    public int CoinsCount => _coinsCount;

    public void TakeCoin(int coinAmount)
    {
        _coinsCount += coinAmount;
    }
}
