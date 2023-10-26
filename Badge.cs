
static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        department = department is null ? "OWNER" : department.ToUpper();

        var idEmployer = id is null ? "" : $"[{id}] - ";

        return $"{idEmployer}{name} - {department}";
    }
}
