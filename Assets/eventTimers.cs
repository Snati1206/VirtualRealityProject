using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This script controls the delays between each main event in the VR experience
// It is responsible for the timing of the events and the activation of the audio and visual effects
// It is also responsible for the reset of everything once it is done

//bool toAlarm;
//bool toMusic;
//bool toReset;


public class eventTimers : MonoBehaviour
{
    public Dictionary<string, float> timers = new Dictionary<string, float>
    {
        { "toAlarm", 0f },
        { "toMusic", 0f },
        { "toReset", 0f }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // List of main events
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void activateMainEvents( bool trigger, string eventName, float timeWait)
    {
        
    }
}
