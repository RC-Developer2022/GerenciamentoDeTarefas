using Flunt.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefas.Domain.Entitys;

[Table(name: "Person")]
public class Person : BaseEntity
{
    public Person()
    {

    }

    public string LastName { get; set; } = string.Empty;

    public string Identity { get; set; } = string.Empty;
    public string IndividualRegistration { get; set; } = string.Empty;
    
    public DateTime DateBirth { get; set; }


    private void Validation() 
    {
        var contract = new Contract<Person>();

        contract.Requires()
            .IsNotNullOrEmpty(Name , "The name cannot be null or empty")
            .IsNotNullOrEmpty(LastName , "The last name cannot be null or empty")
            .IsNotNullOrEmpty(Identity , "Identity cannot be null or empty")
            .IsNotNullOrEmpty(IndividualRegistration, "Individual registration cannot be null or empty");

        AddNotifications(contract);
    }
}
