using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempTransition : MonoBehaviour
{
    public Animator an;

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TransitionToNextLevel());
    }

    IEnumerator TransitionToNextLevel()
    {
        an.SetTrigger("Transition");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("WinScene");
    }
}
