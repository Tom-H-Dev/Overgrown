using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagers : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _backgroundMusic;
    private AudioSource _audioSource;

    private int lastIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        int index = Random.Range(0, _backgroundMusic.Count);
        if (index == lastIndex)
        {
            StartCoroutine(PlayMusic());
            yield break;
        }
        _audioSource.clip = _backgroundMusic[index];
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
        lastIndex = index;
        StartCoroutine(PlayMusic());
    }
}
