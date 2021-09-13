using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickStart()
    {


        
        GameStatus.health = 0.5f;
        GameStatus.fun = 0.5f;
        GameStatus.knowledge = 0.5f;
        GameStatus.energy = 1.0f;

        SceneManager.LoadScene("MorningScene");
        //EventBroadcaster.Instance.PostEvent(EventNames.FindShoe.ON_START_GAME);
        //controller.onCLickStart();

    }

    public void ClickExit()
    {
        Application.Quit();
        //controller.onClickEnd();
    }
}
