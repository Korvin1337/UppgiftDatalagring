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
            /*ProjectId = _inputHandler.GetInput("Enter project ID: "),*/
            ProjectName  = _inputHandler.GetInput("Enter project name: "),
            StartDate = _inputHandler.GetInput("Enter start date: "),
            EndDate = _inputHandler.GetInput("Enter end date: "),
            ProjectManager = _inputHandler.GetInput("Enter project manager: "),
            CustomerId = Int32.Parse(_inputHandler.GetInput("Enter customer Id: ")),
            TotalCost = Decimal.Parse(_inputHandler.GetInput("Enter total cost: ")),
            Status  =  _inputHandler.GetInput("Enter status: ")
        };
    }

    public virtual ProjectUpdateForm CollectProjectUpdateData()
    {
        return new ProjectUpdateForm
        {
            ProjectName = _inputHandler.GetInput("Enter project name: "),
            StartDate = _inputHandler.GetInput("Enter start date: "),
            EndDate = _inputHandler.GetInput("Enter end date: "),
            ProjectManager = _inputHandler.GetInput("Enter project manager: "),
            CustomerId = Int32.Parse(_inputHandler.GetInput("Enter customer Id: ")),
            TotalCost = Decimal.Parse(_inputHandler.GetInput("Enter total cost: ")),
            Status = _inputHandler.GetInput("Enter status: (Not Started, Ongoing, Completeted)")
        };
    }
}
