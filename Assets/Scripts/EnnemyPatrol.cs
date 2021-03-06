using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;
    public int damage = 20;

    void Start()
    {
        target = waypoints[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }
}
