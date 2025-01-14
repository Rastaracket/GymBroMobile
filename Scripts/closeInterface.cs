using UnityEngine;
using UnityEngine.UI;

public class closeInterface : MonoBehaviour
{
    public GameObject uiPanel;
    public Animator animator;  // Der Animator des Objekts

    void Update()
    {
        // Für Maus- oder Touch-Eingaben
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 inputPosition = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    OnButtonClick();
                }
            }
        }
    }
    public void OnButtonClick()
    {
        if (uiPanel != null && uiPanel.CompareTag("Open")) 
        {
            animator.SetTrigger("CloseTrigger");
            uiPanel.tag = "Closed";
        }
    }
}