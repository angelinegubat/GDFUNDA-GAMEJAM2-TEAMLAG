using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickMain()
    {

        SceneManager.LoadScene("Title Screen");
        

    }

    public void ClickContinue()
    {
        pauseScreen.SetActive(false);
    }

    public void ClickSick()
    {
        EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
        EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_24");
        GameStatus.energy = 1.0f;
        GameStatus.health = 0.8f;
        GameStatus.fun = GameStatus.fun / 2;
        GameStatus.knowledge = GameStatus.knowledge / 2;
        pauseScreen.SetActive(false);
        EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
    }

    public void ClickFaint()
    {
        EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
        EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_3");
        GameStatus.energy = 0.3f;
        GameStatus.health = GameStatus.health / 2;
        GameStatus.fun = GameStatus.fun / 2;
        GameStatus.knowledge = GameStatus.knowledge / 2;
        pauseScreen.SetActive(false);
        EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
    }
}
