using UnityEngine;

public class TestProjection : MonoBehaviour
{
    public Transform playerCam;
    public Transform photoPlane;
    public Transform objectPlane;
    public float finalDistance = 20f;
    private float initialDistance;

    private Vector3 initialPos;
    private Vector3 initialScale;

    void Start()
    {
        initialPos = photoPlane.position;
        initialScale = photoPlane.localScale;
        initialDistance = Vector3.Distance(playerCam.position, initialPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ExpandToWorld();
        }
    }

    public void ExpandToWorld()
    {
        objectPlane.rotation = photoPlane.rotation;
        photoPlane.gameObject.SetActive(false);

        float scaleFactor = finalDistance / initialDistance;
        objectPlane.localScale = initialScale * scaleFactor;

        objectPlane.position = playerCam.position + playerCam.forward * finalDistance;
    }
}
