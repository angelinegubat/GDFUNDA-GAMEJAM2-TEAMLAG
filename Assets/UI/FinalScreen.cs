using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private Text FinalText;
    [SerializeField] private Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //EventBroadcaster.Instance.AddObserver("LOSE_SCREEN", this.changeToLose);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToLose()
    {
        FinalText.text = "Game Over";
        ScoreText.text = ":(";
    }
}
