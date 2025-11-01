using UnityEngine;

public class PaintingPicture : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject backgroundObj;

    public void Interact()
    {
        transform.SetParent(Camera.main.transform);
        transform.localScale = new Vector3(0.06f, 0.05f, 0.08f);
        transform.localPosition = new Vector3(0, 0, 1);
        transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
        PlayerProjectionInteract.Instance.CarryThisPicture(this, Instantiate(backgroundObj));
    }
}
