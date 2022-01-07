using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs.Opt
{
    public class OptResultDto
    {
        public int RatedCluster { get; set; }

        public double[] Values { get; set; }
    }
}
