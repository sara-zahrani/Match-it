using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marbel : MonoBehaviour
{
    public AudioClip mAudioClip;
    AudioSource mAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            mAudioSource.PlayOneShot(mAudioClip);
        }
    }
}
