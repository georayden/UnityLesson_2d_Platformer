using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    private Wallet _wallet;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> CoinChanged;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();

        HealthChanged?.Invoke(_health);
        CoinChanged?.Invoke(_wallet.CoinsCount);
    }

    private void Update()
    {
        if(_health <= 0)
        {
            Die();
        }
    }    

    public void TakeDamage(int damage)
    {        
        _health -= damage;

        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.TakeCoin(coin.Amount);
            CoinChanged?.Invoke(_wallet.CoinsCount);
            coin.Disable();
        }
    }
}
