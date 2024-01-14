using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class LoadChunkArea : MonoBehaviour
{
    [SerializeField] private List<GameObject> _loadChunks, _unloadChuncks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement l_player))
        {
            for (int i = 0; i < _loadChunks.Count; i++)
            {
                _loadChunks[i].SetActive(true);
            }
            for (int i = 0; i < _unloadChuncks.Count; i++)
            {
                _unloadChuncks[i].SetActive(false);
            }
        }
    }
}
