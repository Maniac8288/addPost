﻿using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MainServices : IMainServices
    {
        public MainServices()
        {
            Users = new UserServices();
            Register = new RegisterServices();
        }
        public IUserServices Users { get; set; }
        public IRegisterServices Register { get; set; }

    }
}
