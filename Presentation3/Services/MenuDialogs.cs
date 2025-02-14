using Business.Dtos;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Presentation3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation3.Services;

public class MenuDialogs(ICustomerService customerService, IProjectService projecService, InputHandler inputHandler, ConsoleWrapper consoleWrapper, MessageHandler messageHandler, CustomerInputService customerInputService, ProjectInputService projectInputService) : IMenuDialogs
{
    private readonly ICustomerService _customerService = customerService;
    private readonly IProjectService _projectService = projecService;
    private readonly ConsoleWrapper _consoleWrapper = consoleWrapper;
    private readonly InputHandler _inputHandler = inputHandler;
    private readonly MessageHandler _messageHandler = messageHandler;
    private readonly CustomerInputService _customerInputService = customerInputService;
    private readonly ProjectInputService _projectInputService = projectInputService;

    /* Menu made async again, by suggestion of chatgpt 4, already did it myself previously. */
    public async Task RunMenu()
    {
        while (true)
        {
            await MainMenu();
        }
    }

    /* CHATGPT4o Updated my MainMenu Method to adhere to SRP, now i bind the inputs to the methods instead no need for switch case */
    public async Task MainMenu()
    {
        DisplayMenu();

        var option = _inputHandler.GetInput("Choose Uption: ").ToLower();

        var menuCommands = new Dictionary<String, Func<Task>>
        {
            { "1", CreateCustomer },
            { "2", CreateProject },
            { "3", UpdateCustomer },
            { "4", UpdateProject },
            { "5", DeleteCustomer },
            { "6", DeleteProject },
            { "7", ViewCustomers },
            { "8", ViewProjects },
            { "q", Quit }
        };

        if (menuCommands.ContainsKey(option))
        {
            await menuCommands[option]();
        }
        else
        {
            _messageHandler.ShowMessage("Please enter a valid option.");
        }
    }

    /* By suggestion of chatgpt4o generated and put my display menu is a seperate method to adhere to SRP */
    private void DisplayMenu()
    {
        _consoleWrapper.Write("");
        _consoleWrapper.Write("------------MENU----------------");
        _consoleWrapper.Write("");
        _consoleWrapper.Write($"{"1. ",-5} Create a Customer");
        _consoleWrapper.Write($"{"2. ",-5} Create a Project");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write("");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write($"{"3. ",-5} Update a Customer");
        _consoleWrapper.Write($"{"4. ",-5} Update a Project");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write("");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write($"{"5. ",-5} Delete a Customer");
        _consoleWrapper.Write($"{"6. ",-5} Delete a Project");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write("");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write($"{"7. ",-5} View all Customers");
        _consoleWrapper.Write($"{"8. ",-5} View all Projects");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write("");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write($"{"Q. ",-5} Quit Program");
        _consoleWrapper.Write("--------------------------------");
    }

    public async Task CreateCustomer()
    {
        var customerRegistrationForm = _customerInputService.CollectCustomerData();

        try
        {
            await _customerService.CreateCustomerAsync(customerRegistrationForm);

            _messageHandler.ShowMessage("Customer Successfully Created");
        }
        catch (Exception ex) { 
            _messageHandler.ShowMessage(ex.Message);
        }
    }


    public async Task CreateProject()
    {
        var projectRegistrationForm = _projectInputService.CollectProjectData();

        try
        {
            await _projectService.CreateProjectAsync(projectRegistrationForm);

            _messageHandler.ShowMessage("Project Successfully Created");
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public async Task UpdateCustomer()
    {
        await ViewCustomers();
        _consoleWrapper.Write("Choose a customer by id: (ex 1)");
        int userInput = Int32.Parse(_consoleWrapper.ReadLine());

        var customerUpdateRegistrationForm = _customerInputService.CollectCustomerUpdateData();

        try
        {
            var result = await _customerService.UpdateCustomerAsync(userInput, customerUpdateRegistrationForm);

            _messageHandler.ShowMessage("Customer Successfully Updated");
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public async Task UpdateProject()
    {
        await ViewProjects();
        _consoleWrapper.Write("Choose a project by id: (ex 1)");
        int userInput = Int32.Parse(_consoleWrapper.ReadLine());

        var projectUpdateRegistrationForm = _projectInputService.CollectProjectUpdateData();

        try
        {
            await _projectService.UpdateProjectAsync(userInput, projectUpdateRegistrationForm);

            _messageHandler.ShowMessage("Project Successfully Updated");
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public async Task ViewCustomers()
    {
        try
        {
            var result = await _customerService.GetAllCustomersAsync();

            /* Accessing the result with code generated by chatgpt 4o, i had no idea on how to write the syntax for this since the Result class was invlolved */
            if (result is Result<IEnumerable<Customer>> customerResult && customerResult.Success)
            {
                foreach (var customer in customerResult.Data!)
                {
                    _messageHandler.ShowCustomer(customer);
                }
            } else
            {
                _messageHandler.ShowMessage("No customers found");
            }

            _consoleWrapper.Write("Press enter to continue: ");
            _consoleWrapper.ReadLine();
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public async Task ViewProjects()
    {
        try
        {
            var result = await _projectService.GetAllProjectsAsync();

            /* Accessing the result with code generated by chatgpt 4o, i had no idea on how to write the syntax for this since the Result class was invlolved */
            /*if (result is Result<IEnumerable<Project>> projectResult && projectResult.Success)*/
            if (result is Result<IEnumerable<Project>> projectResult && projectResult.Success && projectResult.Data != null)
            {
                foreach (var project in projectResult.Data!)
                {
                    _messageHandler.ShowProject(project);
                }
            }
            else
            {
                _messageHandler.ShowMessage("No projects found");
            }

            _consoleWrapper.Write("Press enter to continue: ");
            _consoleWrapper.ReadLine();
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public async Task DeleteCustomer()
    {
        await ViewCustomers();
        int deleteData = _customerInputService.CollectDeleteCustomerData();

        try
        {
            await _customerService.DeleteCustomerAsync(deleteData);

            _messageHandler.ShowMessage("Customer Successfully Deleted");
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public async Task DeleteProject()
    {
        await ViewProjects();
        int deleteData = _projectInputService.CollectDeleteProjectData();

        try
        {
            await _projectService.DeleteProjectAsync(deleteData);

            _messageHandler.ShowMessage("Project Successfully Deleted");
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage(ex.Message);
        }
    }

    public string GetQuitOption()
    {
        return _inputHandler.GetInput("Do you want to exit? (y/n): ").ToLower();
    }

    /* Chatgpt4o updated my Quit methods to be able to be binded as option in the dictionary menu option */
    public Task Quit()
    {
        var option = GetQuitOption();

        switch (option)
        {
            case "y":
                Environment.Exit(0);
                break;
            case "n":
                break;
            default:
                _messageHandler.ShowMessage("Invalid input, please enter 'y' to quit or 'n' to keep runiing the program");
                return Quit();
        }

        return Task.CompletedTask;
    }
}
