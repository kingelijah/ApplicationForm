﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForm.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }

   
}
