using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{
    
    public AudioSource menumusik;
    public AudioSource buttonHover;
    public AudioSource buttonClick;


    void Awake()
    {
        Button[] buttons = GetComponentsInChildren<Button>(true);

        foreach (Button btn in buttons)
        {
            AddHoverSound(btn);
        }
        
    }
    
    
    void AddHoverSound(Button button)
    {
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>(); //holt sich on event trigger alle buttons
        if (trigger == null)
        {
            trigger = button.gameObject.AddComponent<EventTrigger>(); //falls kein trigger drauf ist pack einen drauf
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        {
            var eventID = EventTriggerType.PointerEnter;
        }
        
    }

    public void PlayClickSound()
    {
        buttonClick.Play();
    }

    public void PlayHoverSound()
    {
        buttonHover.Play();
    }
}
