using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material day;
    public Material night;
    public Material sets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.CHANGE_NIGHT, this.changeNight);
        EventBroadcaster.Instance.AddObserver(EventNames.CHANGE_DAY, this.changeDay);
        EventBroadcaster.Instance.AddObserver(EventNames.CHANGE_SET, this.changeSet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeNight()
    {
        RenderSettings.skybox = night;
    }

    public void changeDay()
    {
        RenderSettings.skybox = day;
    }

    public void changeSet()
    {
        RenderSettings.skybox = sets;
    }
}
