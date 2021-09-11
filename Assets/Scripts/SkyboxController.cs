using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material day;
    public Material night;
    public Material sets;
    public GameObject directionalLight;
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
        this.StartCoroutine(this.changeNight2(2.0f));
    }

    public void changeDay()
    {
        this.StartCoroutine(this.changeDay2(2.0f));
    }

    public void changeSet()
    {
        this.StartCoroutine(this.changeSet2(2.0f));
    }

    public IEnumerator changeNight2(float secs)
    {
        yield return new WaitForSeconds(secs);
        directionalLight.SetActive(false);
        RenderSettings.skybox = night;
    }

    public IEnumerator changeDay2(float secs)
    {
        yield return new WaitForSeconds(secs);
        directionalLight.SetActive(true);
        RenderSettings.skybox = day;
    }

    public IEnumerator changeSet2(float secs)
    {
        yield return new WaitForSeconds(secs);
        directionalLight.SetActive(true);
        RenderSettings.skybox = sets;
    }

    
}
