using System;
using System.Collections.Generic;

namespace Domein.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}