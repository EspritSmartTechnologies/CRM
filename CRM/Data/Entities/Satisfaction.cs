﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public enum Level
    {
        Très,
        Satisfait,
        Peu,
        Non
    }
    public class Satisfaction
    {
        [Key]
        public int IdSatisfaction { get; set; }
        public User User { get; set; }
        public Level Level { get; set; }
        public Claim Claim { get; set; }

    }
}
