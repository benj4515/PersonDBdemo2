namespace personsDBdemo;

public class Person
{
    public Person(string id, string name, DateTime createdAt, int age)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        Age = age;
    }

    public string Id { get; set; } = null;
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Age { get; set; }
}