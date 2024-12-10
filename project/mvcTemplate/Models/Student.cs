using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace mvc.Models;

public enum Major
{
    CS, IT, MATHS, OTHER
}
public class Student
{
    internal Major major;

    // ecrire des variables d'instance 
    [Required]
    public int Id {get;set; }
 [StringLength(20,MinimumLength = 2)]   
public string Firstname {get;set; }
[StringLength(20,MinimumLength = 2)]   
public string Lastname {get;set; }
[Required]
public int Age {get;set; }
[Required]
public double GPA {get;set; }
[Required]
public Major Major {get;set;} 
public DateTime AdmissionDate {get;set; }

    internal static string? FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}