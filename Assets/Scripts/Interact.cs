using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

        string[] locations = { "Foyer Cabinet", "Foyer Shelves", "Dining Cabinet", "Basket", "Toilet", "Sink", "Vase", "Hallway Shelves", "Bed", "Bedroom Shelves", "Bedroom Desk", "Kitchen Cabinets", "Trashbin", "Boxes",
                                "Fridge", "Left Locker", "Right Locker", "Kitchen Shelves", "Living Room Cabinet", "TV"};

        int RNG = Random.Range(0, locations.Length);

        
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

            if (Input.GetKeyDown(KeyCode.R) && itemBeingPickedUp.name == "Bed")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_8");
            }
            else if(Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Bed")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Laptop")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");
            }
            else if (Input.GetKeyDown(KeyCode.R) && itemBeingPickedUp.name == "Laptop" && GameStatus.classTime == true)
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_3");
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Bathroom")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_30");
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Leave Room")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_30");
            }
            else if (Input.GetKeyDown(KeyCode.R) && itemBeingPickedUp.name == "Leave Room")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_1");
            }
            else if (Input.GetKeyDown(KeyCode.Q) && itemBeingPickedUp.name == "Leave Room")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK_6");
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == GameStatus.location)
            {
                EventBroadcaster.Instance.PostEvent("ON_WIN_GAME");
            }
            else if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Dog")
            {
                EventBroadcaster.Instance.PostEvent("USED_ITEM");
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
}

