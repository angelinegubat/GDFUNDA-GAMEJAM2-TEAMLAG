using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    /*
    [SerializeField] Text timerText;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject GameWinScreen;
    public GameObject NoPass;*/
    public GameObject PauseScreen;
    public GameObject SickScreen;
    public GameObject CovidScreen;
    public GameObject FaintScreen;
    public GameObject StartScreen;
    public GameObject Interact;
    public Text InteractText;
    public Image health;
    public Image fun;
    public Image knowledge;
    public Image energy;
    public GameObject NoFun;
    public GameObject NoFun2;
    //public Text ItemText;
    public float currentTime = 0f;
    public float startTime = 200f;

    // Start is called before the first frame update
    void Start()
    {
        GameStatus.health = 0.5f;
        GameStatus.fun = 0.5f;
        GameStatus.knowledge = 0.5f;
        GameStatus.energy = 1.0f;
        UpdateBars();
        StartScreen.SetActive(true);
        //currentTime = Time.time;
        //GameStatus.location = "Library";
        //Cursor.lockState = CursorLockMode.Confined;

    }

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ON_NEAR_ITEM, this.SeeItem);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_NO_ITEM, this.NoItem);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_UPDATE_BARS, this.UpdateBars);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_LOW_FUN, this.LowFun);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_LOW_FUN2, this.LowFun2);
        EventBroadcaster.Instance.AddObserver(EventNames.FAINT, this.Faint);
        EventBroadcaster.Instance.AddObserver(EventNames.SICKDAY, this.SickDay);
        EventBroadcaster.Instance.AddObserver(EventNames.COVID, this.Covid);
        /*
        EventBroadcaster.Instance.AddObserver(EventNames.ITEM_PICKUP_OVERLAY_ON, this.SeeItem);
        EventBroadcaster.Instance.AddObserver(EventNames.ITEM_PICKUP_OVERLAY_OFF, this.NoItem);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_WIN_GAME, this.SendStatus);
        EventBroadcaster.Instance.AddObserver(EventNames.ITEM_TO_INVENTORY, this.itemInventory);
        EventBroadcaster.Instance.AddObserver(EventNames.USED_ITEM, this.useItem);
        EventBroadcaster.Instance.AddObserver(EventNames.NO_TOYS, this.goAway);*/
        //EventBroadcaster.Instance.AddObserver(EventNames.FindShoe.NO_TOYS, this.goAway);

    }


    void OnDestroy()
    {
        //EventBroadcaster.Instance.RemoveObserver(EventNames.ON_WIN_GAME);
    }
    // Update is called once per frame
    void Update()
    {
        if (!PauseScreen.active )
        {
            
            if (Input.GetKey(KeyCode.Escape))
            {
                PauseScreen.SetActive(!PauseScreen.active);
            } 
            
        }
        
    }


    public void GameOver()
    {
        //Cursor.lockState = CursorLockMode.Confined;
       // GameOverScreen.SetActive(true);
        
    }

    public void SendStatus()
    {
        GameStatus.time = startTime;
 
    }

    private void SeeItem(Parameters parameters)
    {

        string item = parameters.GetStringExtra("item", "SomeItem");
        string interactText;
        if (item == "Bed")
        {
            interactText = "BED\nE - Nap (1 hour)\nR - Sleep (8 hours)";
        }
        else if (item == "Laptop") {
            interactText = "LAPTOP\nE - Play Games (1 hour)\nR - Study (1 hour)";

            if (GameStatus.classTime == true && GameStatus.day == 5)
            {
                interactText = interactText + "\nQ - Take Exam";
            }
            else if (GameStatus.classTime == true)
            {
                interactText = interactText + "\nQ - Attend Class (3 hours)";
            }
        }
        else if (item == "Bathroom")
        {
            interactText = "BATHROOM\nE - Clean Up (30 minutes)";
        }
        else if (item == "Leave Room")
        {
            interactText = "LEAVE ROOM\nE - Jog (30 minutes)\nR - Eat (1 hour)\nQ - Go Party (6 hours)";
        }

        else
        {
            interactText = "Interact with \n" + parameters.GetStringExtra("item", "SomeItem");
        }
            
            
        Interact.SetActive(true);
        InteractText.text = interactText;
        
    }




    public void NoItem()
    {
        Interact.SetActive(false);
    }

    public void UpdateBars()
    {
        
        health.fillAmount = GameStatus.health;
        fun.fillAmount = GameStatus.fun;
        knowledge.fillAmount = GameStatus.knowledge;
        energy.fillAmount = GameStatus.energy;
    }

    public void LowFun2()
    {
        this.StartCoroutine(this.ShowHide2(5.0f));

    }

    public IEnumerator ShowHide2(float secs)
    {

        NoFun2.SetActive(true);
        yield return new WaitForSeconds(secs);
        NoFun2.SetActive(false);

    }

    public void LowFun()
    {
        this.StartCoroutine(this.ShowHide(5.0f));

    }

    public IEnumerator ShowHide(float secs)
    {

        NoFun.SetActive(true);
        yield return new WaitForSeconds(secs);
        NoFun.SetActive(false);

    }

    public void Faint()
    {
        FaintScreen.SetActive(true);
    }
    public void SickDay()
    {
        SickScreen.SetActive(true);
    }

    public void Covid()
    {
        CovidScreen.SetActive(true);
    }
}
