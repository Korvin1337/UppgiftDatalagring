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

    public async Task MainMenu()
    {
        _consoleWrapper.Write("");
        _consoleWrapper.Write("--------------------------------");
        _consoleWrapper.Write($"{"1. ",-5} Create a Customer");
        _consoleWrapper.Write($"{"2. ",-5} Create a Project");
        _consoleWrapper.Write($"{"3. ",-5} Update a Customer");
        _consoleWrapper.Write($"{"4. ",-5} Update a Project");
        _consoleWrapper.Write($"{"5. ",-5} View all Customers");
        _consoleWrapper.Write($"{"6. ",-5} View all Projects");
        _consoleWrapper.Write($"{"Q. ",-5} Quit Program");
        _consoleWrapper.Write("--------------------------------");
        var option = _inputHandler.GetInput("Choose option: ");

        switch (option.ToString().ToLower())
        {
            case "1":
                await CreateCustomer();
                break;
            case "2":
                await CreateProject();
                break;
            case "3":
                await UpdateCustomer();
                break;
            case "4":
                await UpdateProject();
                break;
            case "5":
                await ViewCustomers();
                break;
            case "6":
                await ViewProjects();
                break;
            case "q":
                Quit();
                break;
            default:
                _messageHandler.ShowMessage("Please enter a valid option: ");
                break;
        }
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
            if (result is Result<IEnumerable<Project>> projectResult && projectResult.Success)
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

    public string GetQuitOption()
    {
        return _inputHandler.GetInput("Do you want to exit? (y/n): ").ToLower();
    }

    public void Quit()
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
                Quit();
                break;
        }
    }
}
