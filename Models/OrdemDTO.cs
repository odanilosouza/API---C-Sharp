using System;
using System.Collections.Generic;
using System.Text;

namespace InvestApi.Models;

public class OrdemDTO
{
    public int Id {get; set;}
    public string tickler { get; set; }
    public int quantidade { get; set; }
    public double valor { get; set; }

    public double total { get; set; }

    

}