namespace Tarefas.Application.DTO;

public class PersonDTO
{
    public PersonDTO()
    {
        
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string Identity { get; set; } = string.Empty;
    public string IndividualRegistration { get; set; } = string.Empty;

    public DateTime DateBirth { get; set; }
}
