using MeanShift.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeanShift
{
    public class MeanShift
    {
        private double[][] _data;
        private int[] _bandwitch;
        private double _convergenceMean;

        public MeanShift(double[][] data, int hs, int hr, double convergenceMean)
        {
            _data = data;
            _bandwitch = new int[] { hs, hr };
            _convergenceMean = convergenceMean;
        }

        public void Run()
        {
            #region Initialization
            var dim_dataset = _data[0].Length;
            var no_data_dataset = _data.Length / dim_dataset;
            var no_cluster = 0;
            var bandSq = _bandwitch.Select(v => { return v * v; });
            var dataset_index = new double[no_data_dataset];
            for (var i = 0; i < no_data_dataset; i++)
                dataset_index[i] = i;
            var tracking_array = new bool[no_data_dataset];
            var no_point_4_initial = no_data_dataset;
            var clusterV = new int[no_data_dataset];
            var clustMembsCell = new List<double>();
            var clustCent = new List<double>();
            var rnd = new Random();
            #endregion

            while (no_point_4_initial > 0)
            {
                var random_index = (int)Math.Ceiling((no_point_4_initial - 1e-6) * rnd.NextDouble());
                var random_data_point = (int)dataset_index[random_index];
                var mean_cur = new double[dim_dataset];
                for (var i = 0; i < dim_dataset; i++)
                    mean_cur[i] = _data[i][random_data_point];
                var cluster_members = new List<double>();
                var cluster_mem = new int[no_data_dataset];

                while(true)
                {
                    var squ_Euclidean_distance = new double[2,no_data_dataset];
                    //squ_Euclidean_distance(1,:) = sum(bsxfun(@minus, mean_cur(1:2,:), dataPts(1:2,:)).^ 2); % dist squared from mean to all points still active
                    //squ_Euclidean_distance(2,:) = sum(bsxfun(@minus, mean_cur(3:5,:), dataPts(3:5,:)).^ 2);

                    //var kernel_range_datapoint_index = find(squ_Euclidean_distance(1,:) < bandSq);% points within bandWidth
                }
            }
        }
    }
}
