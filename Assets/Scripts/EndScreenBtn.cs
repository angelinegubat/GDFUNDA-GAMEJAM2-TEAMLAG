using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToMenu()
    {

        SceneManager.LoadScene("Main Menu");
        //EventBroadcaster.Instance.PostEvent(EventNames.FindShoe.ON_START_GAME);
        //controller.onCLickStart();

    }
}
