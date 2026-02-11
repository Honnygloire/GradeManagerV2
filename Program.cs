using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static StudentManager manager = new StudentManager();

    static void Main()
    {
        manager.LoadStudents(FileService.Load());

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== GradeManager V2 ===");
            Console.WriteLine("1. Ajouter un étudiant");
            Console.WriteLine("2. Afficher tous les bulletins");
            Console.WriteLine("3. Rechercher un étudiant");
            Console.WriteLine("4. Modifier les notes d’un étudiant");
            Console.WriteLine("5. Supprimer un étudiant");
            Console.WriteLine("6. Trier les étudiants");
            Console.WriteLine("7. Exporter les bulletins");
            Console.WriteLine("8. Sauvegarder");
            Console.WriteLine("9. Quitter");
            Console.Write("\nChoix : ");

            switch (Console.ReadLine())
            {
                case "1": AddStudent(); break;
                case "2": ShowReports(); break;
                case "3": SearchStudent(); break;
                case "4": EditStudentGrades(); break;
                case "5": DeleteStudent(); break;
                case "6": SortMenu(); break;
                case "7": ExportReports(); break;
                case "8": SaveData(); break;
                case "9": running = false; break;
                default: Console.WriteLine("Choix invalide."); Pause(); break;
            }
        }
    }

    // A — Ajouter un étudiant (avec anti-doublon)
    static void AddStudent()
    {
        Console.Clear();
        Console.Write("Nom de l'étudiant : ");
        string name = Console.ReadLine() ?? "";

        if (manager.Exists(name))
        {
            Console.WriteLine("⚠ Un étudiant avec ce nom existe déjà !");
            Pause();
            return;
        }

        var student = new Student { Name = name };

        Console.WriteLine("Entre les notes (0 à 20). Tape 'fin' pour terminer.");

        while (true)
        {
            Console.Write("Note : ");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "fin")
                break;

            if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 20)
                student.Grades.Add(grade);
            else
                Console.WriteLine("Note invalide.");
        }

        manager.AddStudent(student);
        Console.WriteLine("\nÉtudiant ajouté !");
        Pause();
    }

    // B — Rechercher un étudiant
    static void SearchStudent()
    {
        Console.Clear();
        Console.Write("Nom de l'étudiant : ");
        string name = Console.ReadLine() ?? "";

        var student = manager.FindStudent(name);

        if (student == null)
            Console.WriteLine("Étudiant introuvable.");
        else
            Console.WriteLine(student.GetReport());

        Pause();
    }

    // D — Modifier les notes
    static void EditStudentGrades()
    {
        Console.Clear();
        Console.Write("Nom de l'étudiant : ");
        string name = Console.ReadLine() ?? "";

        var student = manager.FindStudent(name);
        if (student == null)
        {
            Console.WriteLine("Étudiant introuvable.");
            Pause();
            return;
        }

        Console.WriteLine("Anciennes notes : " + string.Join(", ", student.Grades));
        Console.WriteLine("Entre les nouvelles notes (0 à 20). Tape 'fin' pour terminer.");

        List<int> newGrades = new();

        while (true)
        {
            Console.Write("Note : ");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "fin")
                break;

            if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 20)
                newGrades.Add(grade);
            else
                Console.WriteLine("Note invalide.");
        }

        manager.EditGrades(name, newGrades);
        Console.WriteLine("Notes mises à jour !");
        Pause();
    }

    // C — Supprimer un étudiant
    static void DeleteStudent()
    {
        Console.Clear();
        Console.Write("Nom de l'étudiant à supprimer : ");
        string name = Console.ReadLine() ?? "";

        if (manager.RemoveStudent(name))
            Console.WriteLine("Étudiant supprimé !");
        else
            Console.WriteLine("Étudiant introuvable.");

        Pause();
    }

    // E — Trier
    static void SortMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Trier par nom");
        Console.WriteLine("2. Trier par moyenne (desc)");
        Console.Write("\nChoix : ");

        string choice = Console.ReadLine() ?? "";

        List<Student> sorted = choice switch
        {
            "1" => manager.SortByName(),
            "2" => manager.SortByAverageDescending(),
            _ => null
        };

        if (sorted == null)
        {
            Console.WriteLine("Choix invalide.");
        }
        else
        {
            foreach (var s in sorted)
                Console.WriteLine(s.GetReport());
        }

        Pause();
    }

    static void ShowReports()
    {
        Console.Clear();
        manager.DisplayAllReports();
        Pause();
    }

    static void ExportReports()
    {
        Console.Clear();

        if (manager.Students.Count == 0)
        {
            Console.WriteLine("Aucun étudiant à exporter.");
        }
        else
        {
            string fileName = "bulletins.txt";

            using (var writer = new StreamWriter(fileName))
            {
                foreach (var student in manager.Students)
                    writer.WriteLine(student.GetReport());
            }

            Console.WriteLine($"Bulletins exportés dans {fileName}");
        }

        Pause();
    }

    static void SaveData()
    {
        FileService.Save(manager.Students);
        Console.WriteLine("Données sauvegardées !");
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nAppuie sur une touche...");
        Console.ReadKey();
    }
}
