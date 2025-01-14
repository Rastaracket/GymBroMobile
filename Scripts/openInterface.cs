using UnityEngine;
using UnityEngine.UI;

public class openInterface : MonoBehaviour
{
    public GameObject uiPanel;
    public Animator animator;  // Der Animator des Objekts

    private void OnMouseDown ()
    {
        if (uiPanel != null && !uiPanel.activeSelf)
        {
            uiPanel.SetActive(true);
            uiPanel.tag = "Open";
        }
        else if (uiPanel != null && uiPanel.CompareTag("Closed"))
        {
            animator.SetTrigger("OpenTrigger");
            uiPanel.tag = "Open";
        }
    }
}