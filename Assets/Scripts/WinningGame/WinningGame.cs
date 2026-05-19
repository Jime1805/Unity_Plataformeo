using UnityEngine;

public class WinningGame : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player") return;

        anim.SetTrigger("touched");
    }
}
