using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//using static UnityEditor.Progress;

public class Interact : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;
    public string shoeArea;
    private Item itemBeingPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        GameStatus.classTime = true;
        


    }

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.CLASS_AVAILABLE, this.classAvailable);
        EventBroadcaster.Instance.AddObserver(EventNames.CLASS_UNAVAILABLE, this.classUnavailable);
    }



    // Update is called once per frame
    void Update()
    {
        
        selectItemFromRay();

        if (HasItemTargetted())
        {
            Parameters updateItemParams = new Parameters();
            updateItemParams.PutExtra("item", itemBeingPickedUp.gameObject.name);
            EventBroadcaster.Instance.PostEvent("ON_NEAR_ITEM", updateItemParams);

            //KNOWLEDGE -1/4H
            //HEALTH -1/2H
            //FUN -1/2H
            //ENERGY -1/1H
            if (Input.GetKeyDown(KeyCode.R) && itemBeingPickedUp.name == "Bed")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_8");
                GameStatus.energy = 1.0f;
                GameStatus.fun = GameStatus.fun / 2;
                GameStatus.knowledge -= 0.2f;
                GameStatus.health -=0.2f;
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();

            }
            else if(Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Bed")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");
                GameStatus.energy += 0.10f;
                GameStatus.fun -= 0.05f;
                GameStatus.knowledge -= 0.025f;
                GameStatus.health -= 0.05f;
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Laptop")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");
                GameStatus.energy -= 0.1f;
                GameStatus.fun += 0.2f;
                GameStatus.knowledge -= 0.025f;
                GameStatus.health -= 0.05f;
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();
            }
            else if (Input.GetKeyDown(KeyCode.R) && itemBeingPickedUp.name == "Laptop" )
            {
                if (GameStatus.fun <= 0.1f)
                {
                    EventBroadcaster.Instance.PostEvent("ON_LOW_FUN2");
                }
                else
                {
                    EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                    EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");

                    GameStatus.energy -= 0.1f;
                    GameStatus.fun -= 0.1f;
                    GameStatus.knowledge += 0.1f;
                    GameStatus.health -= 0.05f;
                    levelStatus();
                    EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                    checkEvents();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q) && itemBeingPickedUp.name == "Laptop" && GameStatus.classTime == true)
            {
                if (GameStatus.day == 5)
                {

                    SceneManager.LoadScene("EndScreen");
                }
                else
                {
                    if (GameStatus.fun <= 0.1f)
                    {
                        EventBroadcaster.Instance.PostEvent("ON_LOW_FUN");
                    }
                    else
                    {
                        EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                        EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_3");
                        if (GameStatus.energy <= 0.2f)
                        {
                            GameStatus.energy -= 0.3f;
                            GameStatus.fun -= 0.3f;
                            GameStatus.knowledge += 0.2f;
                            GameStatus.health -= 0.05f;
                        }
                        else
                        {
                            GameStatus.energy -= 0.3f;
                            GameStatus.fun -= 0.3f;
                            GameStatus.knowledge += 0.4f;
                            GameStatus.health -= 0.05f;
                        }

                        levelStatus();
                        EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                        checkEvents();
                    }
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Bathroom")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_30");
                GameStatus.energy -= 0.05f;
                GameStatus.fun -= 0.05f;
                GameStatus.knowledge -= 0.0125f;
                GameStatus.health += 0.1f;
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Leave Room")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_30");
                GameStatus.energy -= 0.2f;
                GameStatus.fun += 0.1f;
                GameStatus.knowledge -= 0.0125f;
                GameStatus.health += 0.1f;
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();
            }
            else if (Input.GetKeyDown(KeyCode.R) && itemBeingPickedUp.name == "Leave Room")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");
                GameStatus.energy -= 0.1f;
                //GameStatus.fun -= 0.025f;
                GameStatus.knowledge -= 0.05f;
                GameStatus.health += 0.3f;
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();
            }
            else if (Input.GetKeyDown(KeyCode.Q) && itemBeingPickedUp.name == "Leave Room")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_6");
                GameStatus.energy -= 0.6f;
                GameStatus.fun = 1.0f;
                GameStatus.knowledge -= 0.15f;
                GameStatus.health -= 0.3f;

                int RNG = Random.Range(0, 11);
                if (RNG <= 3)
                {
                    GameStatus.knowledge = 0.00f;
                    EventBroadcaster.Instance.PostEvent("COVID");
                }
                levelStatus();
                EventBroadcaster.Instance.PostEvent("ON_UPDATE_BARS");
                checkEvents();
            }
            
        }
        else
        {
            EventBroadcaster.Instance.PostEvent("ON_NO_ITEM");
        }
        
        
    }

    private bool HasItemTargetted()
    {
        return itemBeingPickedUp != null;
    }

    private void selectItemFromRay()
    {
        Ray ray = cam.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 3f, mask))
        {
            var hitItem = hitInfo.collider.GetComponent<Item>();

            if (hitItem == null)
            {
                itemBeingPickedUp = null;
            }
            else if (hitItem != null && hitItem != itemBeingPickedUp)
            {
                itemBeingPickedUp = hitItem;
            }
        }
        else
        {
            itemBeingPickedUp = null;
        }
    }

    public void classAvailable()
    {
        GameStatus.classTime = true;
    }

    public void classUnavailable()
    {
        GameStatus.classTime = false;
    }

    public void levelStatus()
    {
        if (GameStatus.fun < 0)
        {
            GameStatus.fun = 0.0f;
        }
        if (GameStatus.health < 0.0f)
        {
            GameStatus.health = 0.0f;
        }
        if (GameStatus.energy < 0.0f)
        {
            GameStatus.energy = 0.0f;
        }
        if (GameStatus.knowledge < 0.0f)
        {
            GameStatus.knowledge = 0.0f;
        }
        if(GameStatus.fun > 1.0f)
        {
            GameStatus.fun = 1.0f;
        }
        if (GameStatus.energy > 1.0f)
        {
            GameStatus.energy = 1.0f;
        }
        if (GameStatus.knowledge > 1.0f)
        {
            GameStatus.knowledge = 1.0f;
        }
        if (GameStatus.health > 1.0f)
        {
            GameStatus.health = 1.0f;
        }
    }

    public void checkEvents()
    {
        if(GameStatus.health == 0.00f)
        {
            EventBroadcaster.Instance.PostEvent("SICKDAY");
        } else if (GameStatus.energy == 0.00f)
        {
            EventBroadcaster.Instance.PostEvent("FAINT");
        }
    }
}

