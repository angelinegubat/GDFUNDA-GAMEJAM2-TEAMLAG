using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.UPDATE_CLOCK, this.ScreenDark);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenDark()
    {
        anim.Play("blackscreen");
    }
}
