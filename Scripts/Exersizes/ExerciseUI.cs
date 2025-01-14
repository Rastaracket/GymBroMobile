using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseUI : MonoBehaviour {
    public GameObject subcategoryPrefab; // Prefab für Subkategorien (mit Text und Übungen)
    public GameObject exercisePrefab; // Prefab für einzelne Übungen
    public Transform contentParent; // ScrollView Content-Parent, der alle Panels enthält (für die Kategorien)

    private List<ExerciseCategory> categories;

void Start() {
    Debug.Log("Starte Display...");
    LoadJSON();
    DisplayCategories(); 
}

void LoadJSON() {
    TextAsset jsonFile = Resources.Load<TextAsset>("exercises");
    if (jsonFile != null) {
        Debug.Log("JSON-Datei erfolgreich geladen: " + jsonFile.text);
        var wrapper = JsonUtility.FromJson<ExerciseWrapper>(jsonFile.text);
        if (wrapper != null && wrapper.Categories != null) {
            Debug.Log("Kategorien erfolgreich geladen: " + wrapper.Categories.Count + " Kategorien gefunden.");
            categories = wrapper.Categories;
        } else {
            Debug.LogError("Fehler beim Parsen der JSON-Daten: Keine Kategorien gefunden.");
        }
    } else {
        Debug.LogError("JSON-Datei nicht gefunden!");
    }
}

    public void DisplayCategories() {
        // Durchlaufe jede Kategorie und fülle die Panels mit Unterkategorien und Übungen
        foreach (var category in categories) {
            // Finde das Panel für die aktuelle Kategorie (dieses Panel muss bereits im Hierarchie-Tree vorhanden sein)
            GameObject categoryPanel = FindCategoryPanel(category.Category);
            if (categoryPanel != null) {
                
                
                /* Durchlaufe alle Subkategorien dieser Kategorie

                SUBKATEGORIEN!
                
                foreach (var subcategory in category.Subcategories) {
                    // Subkategorie-Objekt instanziieren
                    GameObject subcategoryObj = Instantiate(subcategoryPrefab, categoryPanel.transform);
                    Text subcategoryText = subcategoryObj.GetComponentInChildren<Text>();
                    subcategoryText.text = subcategory.Name;

                }

                */

                    // Übungen in der Subkategorie hinzufügen
                    Transform exerciseParent = categoryPanel.transform.Find("ExerciseParent");
                    foreach (var exercise in category.Exercises) {
                        GameObject exerciseObj = Instantiate(exercisePrefab, exerciseParent);
                        var exerciseScript = exerciseObj.GetComponent<ExerciseItemUI>();
                        exerciseScript.SetExercise(exercise.Name, exercise.Description);
                    }
                
            }
        }
    }

    // Finde das Panel der Kategorie anhand des Namens
    private GameObject FindCategoryPanel(string categoryName) {
        // Suche im Hierarchie-Tree nach dem Panel mit dem entsprechenden Namen
        foreach (Transform child in contentParent) {
            if (child.name == categoryName) {
                Debug.Log("Kategorie gefunden!");
                return child.gameObject; // Panel der Kategorie gefunden
            }
        }
        return null; // Kein Panel gefunden
    }
}
