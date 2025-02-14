using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

public class MessageHandler(ConsoleWrapper consoleWrapper)
{
    private readonly ConsoleWrapper _consoleWrapper = consoleWrapper;

    public void ShowMessage(string message)
    {
        _consoleWrapper.Clear();
        _consoleWrapper.Write(message);
        _consoleWrapper.ReadKey();
    }

    public string FormatCustomerDetails(Customer customer)
    {
        return $"Customer ID: {customer.CustomerId}\n" +
               $"First Name: {customer.Name}\n" +
               $"Email: {customer.Email}\n";
    }

    public string FormatProjectDetails(Project project)
    {
        return $"Project ID: {project.ProjectId}\n" +
               $"Name: {project.ProjectName}\n" +
               $"Start Date: {project.StartDate}\n" +
               $"End Date: {project.EndDate}\n" +
               $"Project Manager: {project.ProjectManager}\n" +
               $"Customer Id: {project.CustomerId}\n" +
               $"Total Cost: {project.TotalCost}\n" +
               $"Status: {project.StatusId}\n";
    }

    public void ShowCustomer(Customer customer)
    {
        _consoleWrapper.Write(FormatCustomerDetails(customer));
    }

    public void ShowProject(Project project)
    {
        _consoleWrapper.Write(FormatProjectDetails(project));
    }
}
