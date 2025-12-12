using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource movementSource;
    
    [Header("3D Sources")]
    public AudioSource houseSource;

    [Header("Clips - Atmosphere")]
    public AudioClip backgroundMusic;

    [Header("Clips - SFX")]
    public AudioClip collectClip;
    public AudioClip boostClip;
    public AudioClip speedPadClip;
    public AudioClip crashClip;
    public AudioClip interactCollectClip;

    public AudioClip footstepClip1;
    public AudioClip footstepClip2;
    public AudioClip footstepClip3;
    public AudioClip footstepClip4;
    
    public AudioClip dashClip;
    public AudioClip jumpClip;
    public AudioClip jumpPowerUpClip;
    public AudioClip houseClip;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void PlayCollect()  => PlaySFX(collectClip);
    public void PlayBoost()    => PlaySFX(boostClip);
    public void PlaySpeedPad() => PlaySFX(speedPadClip);
    public void PlayCrash()    => PlaySFX(crashClip);

    public void PlayDash()         => PlaySFX(dashClip);
    public void PlayJump()         => PlaySFX(jumpClip);
    public void PlayJumpPowerUp()  => PlaySFX(jumpPowerUpClip);

    void PlaySFX(AudioClip clip)
    {
        if (clip != null) sfxSource.PlayOneShot(clip);
    }

    public void PlayInteractCollect()
    {
        if (interactCollectClip != null)
            sfxSource.PlayOneShot(interactCollectClip);
    }
    public void HandleFootsteps(bool isMoving, float currentSpeed)
    {
        if (isMoving && currentSpeed > 0.5f)
        {
            if (!movementSource.isPlaying)
            {
                AudioClip[] steps = { footstepClip1, footstepClip2, footstepClip3, footstepClip4 };
                movementSource.clip = steps[Random.Range(0, steps.Length)];
                movementSource.Play();
            }
            movementSource.pitch = 0.9f + (currentSpeed / 20f);
        }
        else
        {
            if (movementSource.isPlaying) movementSource.Stop();
        }
    }
    
    public void PlayHouseSound()
    {
        
    }

    public void StopHouseSound()
    {

    }
}