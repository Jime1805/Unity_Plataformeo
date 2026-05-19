using UnityEngine;

  public class WinningGame : MonoBehaviour
  {
      private Animator anim;
      private Spawner spawner;

      private void Awake()
      {
          anim = GetComponent<Animator>();
          spawner = GetComponent<Spawner>();
      }

      void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.gameObject.tag != "Player") return;

          anim.SetTrigger("touched");
          spawner?.StartSpawning();
      }
  }