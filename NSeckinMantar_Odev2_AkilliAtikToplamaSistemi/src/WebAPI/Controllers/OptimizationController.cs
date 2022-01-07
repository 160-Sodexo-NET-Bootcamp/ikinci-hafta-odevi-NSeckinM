using ApplicationCore.Entities;
using ApplicationCore.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Opt;

namespace WebAPI.Controllers
{
    [Route("api/v1/Optimizations")]
    [ApiController]
    public class OptimizationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OptimizationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetContainer(int id)
        {
            Vehicle vehicle = await _unitOfWork.Vehicles.GetVehicleWithContainers(id);

            List<Container> containers = vehicle.Containers;

            List<OptContainerDto> conlist = containers.Select(x => new OptContainerDto() { Latitude = (double)x.Latitude, Longitude = (double)x.Longitude ,Id = x.Id}).ToList();

            int clusterNumber = containers.Count % 2 == 0 ? clusterNumber = 2 : clusterNumber = 3;

            var dataForm = conlist.Select(n => new double[] { n.Latitude, n.Longitude , n.Id}).ToArray();


            return Ok(KMeans(dataForm, clusterNumber));

        }

        static double MeasureDistance(double[] firstNode, double[] secondNode)
        {
            var Hipotenus = firstNode.Zip(secondNode,(n1, n2) => Math.Pow(n1 - n2, 2)).Sum();
            return Math.Sqrt(Hipotenus);
        }

        static IList<OptResultDto> KMeans(double[][] conlist, int clusterNumber)
        {
            var dimensionNumber = conlist[0].Length;
            var limit = 10_000;
            var isUpdated = true;
            var random = new Random(5555);

            // Gelen verilerin hepsini rastgele bir kümeye ata
            var resultCluster = Enumerable.Range(0, conlist.Length)
                .Select(index => (RatedCluster: random.Next(0, clusterNumber),Values: conlist[index])).ToList();

            while (--limit > 0)
            {
                // kümelerin merkez noktalarını hesapla
                var centralPoints = Enumerable.Range(0, clusterNumber).AsParallel()
                    .Select(clusterNo =>(cluster: clusterNo,centralPoint: Enumerable.Range(0,dimensionNumber)
                    .Select(axis => resultCluster.Where(s => s.RatedCluster == clusterNo)
                    .Average(s => s.Values[axis]))
                    .ToArray())).ToArray();

                // Sonuç kümesini merkeze en yakın ile güncelle
                isUpdated = false;
                //for (int i = 0; i < sonucKumesi.Count; i++)
                Parallel.For(0, resultCluster.Count, i =>
                {
                    var row = resultCluster[i];
                    var oldRatedCluster = row.RatedCluster;
                    var newRatedCluster = centralPoints.Select(n => (clusterNo: n.cluster, Distance: MeasureDistance(row.Values, n.centralPoint)))
                                         .OrderBy(x => x.Distance).First().clusterNo;
                    
                    if (newRatedCluster != oldRatedCluster)
                    {
                        resultCluster[i] = (RatedCluster: newRatedCluster, Values: row.Values);
                        isUpdated = true;
                    }
                });

                if (!isUpdated)
                {
                    break;
                }

            }
                List<OptResultDto> resultdto = resultCluster.Select(x => new OptResultDto() { RatedCluster = x.RatedCluster, Values = x.Values }).ToList();

            return resultdto;


        }

    }

}
