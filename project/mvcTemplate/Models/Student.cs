using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace mvc.Models;

public enum Major
{
    CS, IT, MATHS, OTHER
}
public class Student : IdentityUser
{
    internal Major major;

   
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

    internal void Remove(Student student)
    {
        throw new NotImplementedException();
    }
}