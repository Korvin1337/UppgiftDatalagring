using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models;

public class Project
{
    /* Use this to for example decide what is shown in GetAllProjecs in ProjectService */

    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string ProjectManager { get; set; } = null!;

    public int CustomerId { get; set; }

    public decimal TotalCost { get; set; }

    public int StatusId { get; set; }
}
