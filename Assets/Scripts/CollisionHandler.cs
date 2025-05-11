using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem crashVFX;

    AudioSource audioSource;
    
    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();    
    }

    void StartCrashSequence()
    {
        //audioSource.Stop();
        //audioSource.PlayOneShot(crash);
        crashVFX.Play();
        GameObject.Find("Ship").SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
