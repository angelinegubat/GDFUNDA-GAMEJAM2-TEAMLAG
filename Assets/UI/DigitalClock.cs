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
        GameStatus.day = 1;
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_30", this.update30);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_1", this.update1);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_3", this.update3);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_6", this.update6);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_8", this.update8);
        textClock.text = "Day " + GameStatus.day + "\n" + hours.ToString() + ":" + minutes.ToString() + "0";
    }

    // Update is called once per frame
    void Update()
    {
    }


    // 1 hour

    //30 mins

    // 3 hours

    //8 hours
    public void update30()
    {
        minutes += 3;

        if(minutes >= 6)
        {
            minutes = 0;
            hours++;

            if((hours >= 17 && hours < 18) || (hours >= 5 && hours < 6))
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_SET");
            }
            else if (hours >= 18 || hours < 5)
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
            } else
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
            }
            if(hours > 23)
            {
                hours = 0;
                GameStatus.day++;
            }
        }

        checkClass();

        textClock.text = "Day " + GameStatus.day + "\n" + hours.ToString() + ":" + minutes.ToString() + "0";
    }

    public void update1()
    {
        hours++;
        if (hours > 23)
            {
                hours = 0;
            GameStatus.day++;
        }

        if ((hours >= 17 && hours < 18) || (hours >= 5 && hours < 6))
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_SET");
            }
            else if (hours >= 18 || hours < 5)
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
            }
            else
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
            }

        textClock.text = "Day " + GameStatus.day + "\n" + hours.ToString() + ":" + minutes.ToString() + "0";

        checkClass();
    }

    public void update8()
    {
        hours+=8;
        if (hours > 23)
        {
            hours = hours % 24;
            GameStatus.day++;
        }

        if ((hours >= 17 && hours < 18) || (hours >= 5 && hours < 6))
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_SET");
        }
        else if (hours >= 18 || hours < 5)
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
        }

        textClock.text = "Day " + GameStatus.day + "\n" + hours.ToString() + ":" + minutes.ToString() + "0";

        checkClass();
    }

    public void update3()
    {
        hours += 3;
        if (hours > 23)
        {
            hours = hours % 24;
            GameStatus.day++;
        }

        if ((hours >= 17 && hours < 18) || (hours >= 5 && hours < 6))
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_SET");
        }
        else if (hours >= 18 || hours < 5)
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
        }

        textClock.text = "Day " + GameStatus.day + "\n" + hours.ToString() + ":" + minutes.ToString() + "0";

        checkClass();
    }

    public void update6()
    {
        hours += 6;
        if (hours > 23)
        {
            hours = hours % 24;
            GameStatus.day++;
        }

        if ((hours >= 17 && hours < 18) || (hours >= 5 && hours < 6))
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_SET");
        }
        else if (hours >= 18 || hours < 5)
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
        }

        textClock.text = "Day " + GameStatus.day + "\n" + hours.ToString() + ":" + minutes.ToString() + "0";

        checkClass();
    }

    public void checkClass()
    {
        if (hours >= 9 && hours <= 16){
            EventBroadcaster.Instance.PostEvent("CLASS_AVAILABLE");
        } else
        {
            EventBroadcaster.Instance.PostEvent("CLASS_UNAVAILABLE");
        }
    }

}
