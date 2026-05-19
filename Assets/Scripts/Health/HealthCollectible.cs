using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player") return;
        collision.GetComponent<Health>().AddHealth(healthValue);
        anim.SetTrigger("pickUp");
        Destroy(gameObject, 1.0f);
    }
}
