﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Super_Hero_Project.Models
{
    public class SuperHeroModels
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string AlterEgo { get; set; }
        public string PrimaryAbility { get; set; }
        public string AlternativeAbility { get; set; }
        public string CatchPhrase { get; set; }
    }
}