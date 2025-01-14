using System.Collections.Generic;

[System.Serializable]
public class ExerciseWrapper {
    public List<ExerciseCategory> Categories;
}

[System.Serializable]
public class ExerciseCategory {
    public string Category;
    public List<Exercise> Exercises;
}


[System.Serializable]
public class Exercise {
    public string Name;
    public string Description;
}
