using UnityEngine;

public class Mailbox : Interactable
{
    [Header("Visual")]
    public GameObject letterVisual;  
    public GameObject lightVisual;    
    
    public AudioSource mailboxSource;
    public AudioClip mailboxClip;

    [Header("Effects")]
    public ParticleSystem collectParticles;

    private bool hasLetter = false;

    void Start()
    {
        UpdateVisual();
    }

    public void PlaceLetter()
    {
        hasLetter = true;
        UpdateVisual();

        // 🔊 3D Mailbox Sound starten
        if (mailboxSource != null && mailboxClip != null)
        {
            mailboxSource.clip = mailboxClip;
            mailboxSource.loop = true;
            mailboxSource.spatialBlend = 1f;   // 3D
            mailboxSource.minDistance = 5f;
            mailboxSource.maxDistance = 50f;
            mailboxSource.Play();
        }
    }

    public override void Interact()
    {
        base.Interact();

        if (!hasLetter) return;

        hasLetter = false;
        UpdateVisual();

        if (collectParticles != null)
            collectParticles.Play();
        
        if (mailboxSource != null)
            mailboxSource.Stop();

        if (MailGameManager.instance != null)
            MailGameManager.instance.CollectLetter();
    }

    public bool HasLetter()
    {
        return hasLetter;
    }

    void UpdateVisual()
    {
        if (letterVisual != null)
            letterVisual.SetActive(hasLetter);
        
        if (lightVisual != null)
            lightVisual.SetActive(hasLetter);
    }
}