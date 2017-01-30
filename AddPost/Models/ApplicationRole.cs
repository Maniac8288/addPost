using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationRole : IdentityRole
{
    public ApplicationRole() { }

    public string Description { get; set; }
}