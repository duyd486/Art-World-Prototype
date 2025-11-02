using UnityEngine;

public class PlayerProjectionInteract : MonoBehaviour
{
    public static PlayerProjectionInteract Instance { get; private set; }

    public Transform playerCam;
    public float finalDistance = 20f;

    private Transform photoPlane;
    private Transform objectPlane;
    private float initialDistance;

    private Vector3 initialPos;
    private Vector3 initialScale;

    private bool isCarryPicture = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isCarryPicture)
            {
                ExpandToWorld();
            }
        }
    }

    public void CarryThisPicture(PaintingPicture picture, GameObject backgroundObject)
    {
        photoPlane = picture.transform;
        objectPlane = backgroundObject.transform;
        isCarryPicture = true;
        initialPos = photoPlane.position;
        initialScale = photoPlane.localScale;
        initialDistance = Vector3.Distance(playerCam.position, initialPos);
    }

    public void ExpandToWorld()
    {
        objectPlane.rotation = photoPlane.rotation;
        photoPlane.gameObject.SetActive(false);

        float scaleFactor = finalDistance / initialDistance;
        objectPlane.localScale = initialScale * scaleFactor;

        objectPlane.position = playerCam.position + playerCam.forward * finalDistance;

        objectPlane.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        isCarryPicture = false;
    }
}
