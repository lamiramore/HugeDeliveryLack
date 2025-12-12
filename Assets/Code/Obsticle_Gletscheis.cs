using UnityEngine;

public class Obsticle_Gletscheis : MonoBehaviour
{
    [Header("Settings")]
    public float slowMultiplier = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if (p != null)
        {
            p.currentSpeed *= 1 / slowMultiplier;
            p.environmentSpeedMultiplier = 1f / slowMultiplier;
            
            if (AudioManager.instance != null)
            {
                if (Mathf.Approximately(slowMultiplier, 0.6f))
                {
                    AudioManager.instance.PlaySpeedPanel();
                }
                else if (slowMultiplier > 1f)
                {
                    AudioManager.instance.PlayCrash();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if (p != null)
        {
            p.environmentSpeedMultiplier = 1f;
        }
    }
}
