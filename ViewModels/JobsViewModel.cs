using System;
using System.Text.RegularExpressions;
using JobTracker2.DTOs;
using JobTracker2.Models;

namespace JobTracker2.ViewModels;

public class JobsViewModel
{
    public List<Job> Jobs { get; set; } = new List<Job>();
    public List<GroupByCityDTO> GroupedByCityList { get; set; } = new List<GroupByCityDTO>();

    public List<GroupByPositionDTO> GroupedByPositionList { get; set; } = new List<GroupByPositionDTO>();
}
