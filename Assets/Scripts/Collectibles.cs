using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] GameObject Prompt;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Prompt.SetActive(true);
        }
    }

    public void ClosePrompt()
    {
        Destroy(Prompt);
        Destroy(gameObject);
    }
}
