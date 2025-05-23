using System.Collections;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance = 3f;
    public LayerMask layerMask;

    public TextMeshProUGUI promptText;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        promptText.text = "";
        promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            CheckForItem();
        }
    }

    void CheckForItem()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, maxCheckDistance, layerMask))
        {
            var item = hit.collider.GetComponent<ItemObject>();
            if (item != null && item.data != null)
            {
                ShowPrompt($"{item.data.itemName}\n{item.data.description}");
                return;
            }
        }

        HidePrompt();
    }

    void ShowPrompt(string message)
    {
        promptText.text = message;
        promptText.gameObject.SetActive(true);
    }

    void HidePrompt()
    {
        promptText.text = "";
        promptText.gameObject.SetActive(false);
    }
}