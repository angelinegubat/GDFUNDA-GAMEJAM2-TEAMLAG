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
        

        string[] locations = { "Foyer Cabinet", "Foyer Shelves", "Dining Cabinet", "Basket", "Toilet", "Sink", "Vase", "Hallway Shelves", "Bed", "Bedroom Shelves", "Bedroom Desk", "Kitchen Cabinets", "Trashbin", "Boxes",
                                "Fridge", "Left Locker", "Right Locker", "Kitchen Shelves", "Living Room Cabinet", "TV"};

        int RNG = Random.Range(0, locations.Length);

        
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

            if (Input.GetKeyDown(KeyCode.E) && itemBeingPickedUp.name == "Bed")
            {
                EventBroadcaster.Instance.PostEvent("UPDATE_CLOCK");
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
}

