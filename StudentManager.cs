using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    public List<Student> Students { get; private set; } = new();

    public void LoadStudents(List<Student> students)
    {
        Students = students;
    }

    // A — Empêcher les doublons
    public bool Exists(string name)
    {
        return Students.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    // B — Rechercher un étudiant
    public Student? FindStudent(string name)
    {
        return Students.FirstOrDefault(s =>
            s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // C — Supprimer un étudiant
    public bool RemoveStudent(string name)
    {
        var student = FindStudent(name);
        if (student == null) return false;

        Students.Remove(student);
        return true;
    }

    // D — Modifier les notes
    public bool EditGrades(string name, List<int> newGrades)
    {
        var student = FindStudent(name);
        if (student == null) return false;

        student.Grades = newGrades;
        return true;
    }

    // E — Trier les étudiants
    public List<Student> SortByAverageDescending()
    {
        return Students.OrderByDescending(s => s.Average).ToList();
    }

    public List<Student> SortByName()
    {
        return Students.OrderBy(s => s.Name).ToList();
    }

    public void DisplayAllReports()
    {
        if (Students.Count == 0)
        {
            Console.WriteLine("Aucun étudiant.");
            return;
        }

        foreach (var student in Students)
        {
            Console.WriteLine(student.GetReport());
        }
    }
}
