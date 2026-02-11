using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; } = new();

    public int Total => Grades.Sum();
    public double Average => Grades.Count == 0 ? 0 : Grades.Average();
    public int MaxGrade => Grades.Count == 0 ? 0 : Grades.Max();
    public int MinGrade => Grades.Count == 0 ? 0 : Grades.Min();

    public string GetReport()
    {
        string gradesList = Grades.Count > 0 ? string.Join(", ", Grades) : "Aucune note";

        return
            $"Bulletin de {Name}\n" +
            "------------------\n" +
            $"Notes : {gradesList}\n" +
            $"Somme : {Total}\n" +
            $"Moyenne : {Average:F1}\n" +
            $"Meilleure note : {MaxGrade}\n" +
            $"Pire note : {MinGrade}\n";
    }
}
