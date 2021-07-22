using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] gameObjects;

    private void Awake()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
