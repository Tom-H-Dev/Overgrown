using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class LoadChunkArea : MonoBehaviour
{
    [SerializeField] private GameObject _loadBuildingChunk, _unloadBuildingChunk, _otherAreaLoader;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement l_player))
        {
            _loadBuildingChunk.SetActive(true);
            _unloadBuildingChunk.SetActive(false);
            _otherAreaLoader.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
