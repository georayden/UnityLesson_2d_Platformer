using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coinText;

    private void OnEnable()
    {
        _player.CoinChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _player.CoinChanged -= OnCoinChanged;

    }

    private void OnCoinChanged(int coin)
    {
        _coinText.text = coin.ToString();
    }
}
