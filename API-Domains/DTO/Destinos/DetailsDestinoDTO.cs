﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.DTO.Destinos;

public class DetailsDestinoDTO
{
    public string Name { get; set; }
    public List<string> Pictures { get; set; }
    public string Subtitle { get; set; }
    public double Price { get; set; }
    public string DescriptionPortuguese { get; set; }
    public string DescriptionEnglish { get; set; }
}
