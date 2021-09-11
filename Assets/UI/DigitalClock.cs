using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{
    [SerializeField ]private Text textClock;
    private int hours = 10;
    private int minutes = 0;

    // Start is called before the first frame update
    void Start()
    {
        //EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK", this.updateClock);
        textClock.text = hours.ToString() + ":" + minutes.ToString() + "0";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateClock()
    {
        minutes += 3;

        if(minutes >= 6)
        {
            minutes = 0;
            hours++;
            if(hours > 23)
            {
                hours = 0;
            }
        }

        textClock.text = hours.ToString() + ":" + minutes.ToString() + "0";
    }
}
