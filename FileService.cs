using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class FileService
{
    private const string FileName = "students.json";

    public static void Save(List<Student> students)
    {
        var json = JsonSerializer.Serialize(students, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FileName, json);
    }

    public static List<Student> Load()
    {
        if (!File.Exists(FileName))
            return new List<Student>();

        string json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }
}
