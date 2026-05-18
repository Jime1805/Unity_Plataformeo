using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header ("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered;
    private bool active;
    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && active)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        spriteRend.color = Color.red;
        triggered = true;
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        
        Collider2D player = Physics2D.OverlapBox(
            transform.position, 
            GetComponent<Collider2D>().bounds.size, 
            0, 
            LayerMask.GetMask("Player")
        );
        if (player != null)
            player.GetComponent<Health>().TakeDamage(damage);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
