using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Timer());
    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * 100;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("Main Menu");
    }
}
