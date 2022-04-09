using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VikingRaktar.Models
{
    public class AruKereseshez
    {
        public string MegnevKeres { get; set; }

        public string GyartoKeres { get; set; }

        public SelectList GyartoLista { get; set; }

        public List<Aru> AruLista { get; set; }
    }
}
