using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int SceneIndex;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Transition");
            StartCoroutine(ChangeLevel());
        }
    }
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneIndex);
    }
}
