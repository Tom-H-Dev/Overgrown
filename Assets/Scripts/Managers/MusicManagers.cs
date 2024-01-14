using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagers : MonoBehaviour
{
    public static MusicManagers instance;

    [SerializeField] private List<AudioClip> _backgroundMusic;
    private AudioSource _audioSource;
    [SerializeField] private PlayerClassStats settings;
    private int lastIndex;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
        ChangeVolume();
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

    public void ChangeVolume()
    {
        _audioSource.volume = settings.health;
    }
}
