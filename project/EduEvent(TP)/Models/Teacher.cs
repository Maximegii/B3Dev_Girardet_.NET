using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace EduEvent.Models;
public class Teacher
{
    internal Major major;

    // ecrire des variables d'instance 
    public int Id {get;set; }
public string Firstname {get;set; }
public string Lastname {get;set; }
public int Age {get;set; }
public Major Major {get;set;} 
public DateTime AdmissionDate {get;set; }



}