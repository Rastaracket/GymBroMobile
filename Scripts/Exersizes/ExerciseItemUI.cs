using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExerciseItemUI : MonoBehaviour {
    public TMP_Text nameText; // Name der Übung
    public TMP_Text descriptionText; // Beschreibung der Übung
    public Button toggleButton; // Button mit Pfeil
    public Image arrowImage; // Pfeilsymbol

    private bool isExpanded = false; // Status der Sichtbarkeit

    void Start() {
        //TEST -- SPÄTER ENTFERNEN!!!
    toggleButton.onClick.AddListener(ToggleDescription);
    descriptionText.gameObject.SetActive(false); // Beschreibung ausblenden
        //START VOID IRRELEVANT

    }


    public void SetExercise(string name, string description) {
        nameText.text = name;
        descriptionText.text = description;
        descriptionText.gameObject.SetActive(false); // Beschreibung ausblenden

        toggleButton.onClick.AddListener(ToggleDescription);
    }

    private void ToggleDescription() {
        isExpanded = !isExpanded;
        descriptionText.gameObject.SetActive(isExpanded);

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform.parent);

        // Pfeilrotation
        arrowImage.transform.rotation = isExpanded 
            ? Quaternion.Euler(0, 0, 90) // Nach unten
            : Quaternion.Euler(0, 0, 0); // Nach rechts
    }
}
