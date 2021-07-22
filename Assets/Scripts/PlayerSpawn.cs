using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        Camera.main.transform.position = transform.position;
    }
}
