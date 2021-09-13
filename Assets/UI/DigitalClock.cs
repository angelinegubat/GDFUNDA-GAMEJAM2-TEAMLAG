using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{
    [SerializeField ]private Text textClock;

    //private int hours = 10;
    //private int minutes = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameStatus.hour = 9;
        GameStatus.minute = 0;
        GameStatus.day = 1;
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_30", this.update30);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_1", this.update1);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_3", this.update3);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_6", this.update6);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_8", this.update8);
        EventBroadcaster.Instance.AddObserver("UPDATE_CLOCK_24", this.update24);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_RESTART, this.onRestart);
        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";
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
        GameStatus.minute += 3;

        if(GameStatus.minute >= 6)
        {
            GameStatus.minute = 0;
            GameStatus.hour++;

            if((GameStatus.hour >= 17 && GameStatus.hour < 18) || (GameStatus.hour >= 5 && GameStatus.hour < 6))
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_SET");
            }
            else if (GameStatus.hour >= 18 || GameStatus.hour < 5)
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
            } else
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
            }
            if(GameStatus.hour > 23)
            {
                GameStatus.hour = 0;
                GameStatus.day++;
            }
        }

        checkClass();

        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";
    }

    public void update1()
    {
        GameStatus.hour++;
        if (GameStatus.hour > 23)
            {
            GameStatus.hour = 0;
            GameStatus.day++;
        }

        if ((GameStatus.hour >= 17 && GameStatus.hour < 18) || (GameStatus.hour >= 5 && GameStatus.hour < 6))
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_SET");
            }
            else if (GameStatus.hour >= 18 || GameStatus.hour < 5)
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
            }
            else
            {
                EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
            }

        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";

        checkClass();
    }

    public void update8()
    {
        GameStatus.hour += 8;
        if (GameStatus.hour > 23)
        {
            GameStatus.hour = GameStatus.hour % 24;
            GameStatus.day++;
        }

        if ((GameStatus.hour >= 17 && GameStatus.hour < 18) || (GameStatus.hour >= 5 && GameStatus.hour < 6))
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_SET");
        }
        else if (GameStatus.hour >= 18 || GameStatus.hour < 5)
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
        }

        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";

        checkClass();
    }

    public void update3()
    {
        GameStatus.hour += 3;
        if (GameStatus.hour > 23)
        {
            GameStatus.hour = GameStatus.hour % 24;
            GameStatus.day++;
        }

        if ((GameStatus.hour >= 17 && GameStatus.hour < 18) || (GameStatus.hour >= 5 && GameStatus.hour < 6))
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_SET");
        }
        else if (GameStatus.hour >= 18 || GameStatus.hour < 5)
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
        }

        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";

        checkClass();
    }

    public void update6()
    {
        GameStatus.hour += 6;
        if (GameStatus.hour > 23)
        {
            GameStatus.hour = GameStatus.hour % 24;
            GameStatus.day++;
        }

        if ((GameStatus.hour >= 17 && GameStatus.hour < 18) || (GameStatus.hour >= 5 && GameStatus.hour < 6))
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_SET");
        }
        else if (GameStatus.hour >= 18 || GameStatus.hour < 5)
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_NIGHT");
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("CHANGE_DAY");
        }

        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";

        checkClass();
    }

    public void update24()
    {
       
        GameStatus.day++;

        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";

        checkClass();
        
    }

    public void checkClass()
    {
        if (GameStatus.hour >= 9 && GameStatus.hour <= 16){
            EventBroadcaster.Instance.PostEvent("CLASS_AVAILABLE");
        } else
        {
            EventBroadcaster.Instance.PostEvent("CLASS_UNAVAILABLE");
        }
        checkEnd();
    }

    public void checkEnd()
    {
        if (GameStatus.day > 5 || (GameStatus.day == 5 && GameStatus.hour > 16))
        {
            
            GameStatus.knowledge = 0.00f;
            EventBroadcaster.Instance.PostEvent("MISSED_EXAM");
            
            //SceneManager.LoadScene("EndScreen");
        } 
    }

    public void onRestart()
    {
        textClock.text = "Day " + GameStatus.day + "\n" + GameStatus.hour.ToString() + ":" + GameStatus.minute.ToString() + "0";
    }

}
