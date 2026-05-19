using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float _points = 1;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player") return;
        CoinManager.AddAmount(_points);
        anim.SetTrigger("pickUp");
        Destroy(gameObject, 0.5f);
    }
}
