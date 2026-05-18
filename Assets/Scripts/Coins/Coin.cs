using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float _points = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player") return;
        CoinManager.AddAmount(_points);
        gameObject.SetActive(false);
    }
}
