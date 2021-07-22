using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
