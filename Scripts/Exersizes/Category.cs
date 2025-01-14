using System.Collections.Generic; // Import für Listen
using UnityEngine;

[System.Serializable]
public class Category
{
    public string categoryName;          // Der Name der Kategorie
    public List<Exercise> exercises;     // Liste der Übungen
    public List<Category> subcategories; // Liste der Unterkategorien
}
