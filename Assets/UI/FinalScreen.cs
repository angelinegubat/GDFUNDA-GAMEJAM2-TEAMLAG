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
        changeScore();
    }

    public void changeScore()
    {
        
        float FinalScore = GameStatus.knowledge * 100;
        ScoreText.text = FinalScore.ToString("0.0") + "%";
        if (FinalScore >= 100.0)
        {
            FinalText.text = "Perfection!";
        }
        else if (FinalScore >= 60.0)
        {
            FinalText.text = "You Passed!";
        }
        else
        {
            FinalText.text = "Try Again!";
        }
       
    }
}
