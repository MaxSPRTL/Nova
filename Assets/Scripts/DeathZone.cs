using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private GameObject playerSpawn;
    private PlayerHealth player;
    private int deathZoneDamage = 20;
    private Animator fadeSystem;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer(other));
            
            PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(deathZoneDamage);
        }
    }

    private IEnumerator RespawnPlayer(Collider2D other)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        other.transform.position = playerSpawn.transform.position;
    }
}
