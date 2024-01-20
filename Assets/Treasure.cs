using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class treasure : MonoBehaviour
{
    void Start()
    {
        Debug.Log("start on line 10");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            WinGame();
        }
    }
    private void WinGame()
    {
        
        SceneManager.LoadScene("Win");
    }
}