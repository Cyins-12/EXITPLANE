using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public List<ParticleSystem> apiParticleSystems; // List Particle System api
    public ParticleSystem asapParticleSystem; // Particle System asap dari APAR
    public LayerMask fireLayer; // LayerMask untuk mendeteksi api
    public float detectionRadius = 1.0f; // Radius deteksi asap

    public GameObject[] objectsToDisable; // Objek yang dinonaktifkan saat api mati
    public GameObject objectToEnable; // Objek pertama yang diaktifkan saat api mati
    public GameObject objectToEnable2; // Objek kedua yang diaktifkan saat api mati
    public AudioSource fireExtinguishedAudio; // AudioSource yang akan diputar saat api mati

    private bool audioPlayed = false; // Mencegah audio diputar lebih dari sekali

    private void Start()
    {
        foreach (ParticleSystem api in apiParticleSystems)
        {
            if (api != null)
            {
                api.Play();
            }
        }
    }

    private void Update()
    {
        if (asapParticleSystem.isPlaying)
        {
            ExtinguishFiresInRange();
        }

        if (AreAllFiresExtinguished())
        {
            DisableObjects();
            EnableObjects();
            PlayExtinguishedAudio();
        }
    }

    private void ExtinguishFiresInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(asapParticleSystem.transform.position, detectionRadius, fireLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            ParticleSystem api = hitCollider.GetComponent<ParticleSystem>();
            if (api != null && api.isPlaying)
            {
                api.Stop();
                Debug.Log("Api dimatikan: " + api.gameObject.name);
            }
        }
    }

    private bool AreAllFiresExtinguished()
    {
        foreach (ParticleSystem api in apiParticleSystems)
        {
            if (api != null && api.isPlaying)
            {
                return false;
            }
        }
        return true;
    }

    private void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    private void EnableObjects()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }

        if (objectToEnable2 != null)
        {
            objectToEnable2.SetActive(true);
        }
    }

    private void PlayExtinguishedAudio()
    {
        if (!audioPlayed && fireExtinguishedAudio != null)
        {
            fireExtinguishedAudio.Play();
            audioPlayed = true; // Mencegah audio diputar berulang kali
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(asapParticleSystem.transform.position, detectionRadius);
    }
}
 