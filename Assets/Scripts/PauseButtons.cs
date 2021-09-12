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
}
