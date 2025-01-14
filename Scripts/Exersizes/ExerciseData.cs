using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewExerciseData", menuName = "Exercise Data", order = 1)]
public class ExerciseData : ScriptableObject
{
    public List<Category> categories;  // Liste der Kategorien mit Übungen
}
