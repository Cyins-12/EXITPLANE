using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class APARControllerWithAudio : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public ParticleSystem aparParticleSystem;
    public AudioSource aparAudioSource;
    private bool isGrabbed = false;

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void Update()
    {
        if (isGrabbed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ActivateParticlesAndAudio();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                DeactivateParticlesAndAudio();
            }
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        DeactivateParticlesAndAudio();
    }

    private void ActivateParticlesAndAudio()
    {
        if (!aparParticleSystem.isPlaying)
        {
            aparParticleSystem.Play();
        }

        if (!aparAudioSource.isPlaying)
        {
            aparAudioSource.Play();
        }
    }

    private void DeactivateParticlesAndAudio()
    {
        if (aparParticleSystem.isPlaying)
        {
            aparParticleSystem.Stop();
        }

        if (aparAudioSource.isPlaying)
        {
            aparAudioSource.Stop();
        }
    }
}