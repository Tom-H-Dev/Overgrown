using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private ObjectFader _fader;
    [SerializeField] private GameObject _player;

    void Update()
    {
        if (_player != null)
        {
            Vector3 l_dir = _player.transform.position - transform.position;
            Ray l_ray = new Ray(transform.position, l_dir);
            RaycastHit l_hit;
            if (Physics.Raycast(l_ray, out l_hit))
            {
                if (l_hit.collider == null)
                    return;
                if (l_hit.collider.gameObject == _player)
                {
                    //nothing is in front of the player
                    if (_fader != null)
                    {
                        _fader.doFade = false;
                    }
                }
                else
                {
                    _fader = l_hit.collider.gameObject.GetComponent<ObjectFader>();
                    if (_fader != null)
                    {
                        _fader.doFade = true;
                    }
                }
            }
        }
    }
}
