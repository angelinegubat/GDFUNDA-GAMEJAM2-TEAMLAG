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
    public GameObject Interact;
    public Text InteractText;
    public Image health;
    public Image fun;
    public Image knowledge;
    public Image energy;
    public GameObject NoFun;
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
            //startTime -= 1 * Time.deltaTime;
            //GameStatus.time = startTime;
            //timerText.text = startTime.ToString("0.0");
            /*
            if (startTime <= 0)
            {
                startTime = 0;
                //EventBroadcaster.Instance.PostEvent(EventNames.FindShoe.ON_GAME_OVER);
                GameOver();
            }*/
            if (Input.GetKey(KeyCode.Escape))
            {
                PauseScreen.SetActive(true);
            } 
            /*if(Input.GetKey("e") && InteractText.text == "Interact with /nDog" && ItemText.text == "")
            {
                goAway();
            }*/
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
            if(GameStatus.classTime == true)
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
}
