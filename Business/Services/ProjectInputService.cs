using Business.Dtos;
using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class ProjectInputService(InputHandler inputHandler)
{
    private readonly InputHandler _inputHandler = inputHandler;

    public virtual ProjectRegistrationForm CollectProjectData()
    {
        return new ProjectRegistrationForm
        {
            ProjectName  = _inputHandler.GetInput("Enter project name: "),
            StartDate = DateTime.Parse(_inputHandler.GetInput("Enter start date: (ex 2024-12-24): ")),
            EndDate = DateTime.Parse(_inputHandler.GetInput("Enter end date: (ex 2024-12-24): ")),
            ProjectManager = _inputHandler.GetInput("Enter project manager: "),
            CustomerId = Int32.Parse(_inputHandler.GetInput("Enter customer Id: (ex 1): ")),
            TotalCost = Decimal.Parse(_inputHandler.GetInput("Enter total cost: (decimal 2,22): ")),
            StatusId  =  Int32.Parse(_inputHandler.GetInput("Enter status: 1) Not Started, 2) Ongoing, 3) Completeted): "))
        };
    }

    public virtual ProjectUpdateForm CollectProjectUpdateData()
    {
        return new ProjectUpdateForm
        {
            ProjectName = _inputHandler.GetInput("Enter project name: "),
            StartDate = DateTime.Parse(_inputHandler.GetInput("Enter start date: (ex 2024-12-24): ")),
            EndDate = DateTime.Parse(_inputHandler.GetInput("Enter end date: (ex 2024-12-24): ")),
            ProjectManager = _inputHandler.GetInput("Enter project manager: "),
            CustomerId = Int32.Parse(_inputHandler.GetInput("Enter customer Id: (ex 1): ")),
            TotalCost = Decimal.Parse(_inputHandler.GetInput("Enter total cost: (decimal 2,22): ")),
            StatusId = Int32.Parse(_inputHandler.GetInput("Enter status: 1) Not Started, 2) Ongoing, 3) Completeted): "))
        };
    }

    public virtual int CollectDeleteProjectData()
    {
        return Int32.Parse(_inputHandler.GetInput("Enter project ID to delete: "));
    }
}
