using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
