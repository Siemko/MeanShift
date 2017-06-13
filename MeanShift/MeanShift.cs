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

                }
            }

    while true
        squ_Euclidean_distance(1,:) = sum(bsxfun(@minus, mean_cur(1:2,:), dataPts(1:2,:)).^ 2); % dist squared from mean to all points still active
        squ_Euclidean_distance(2,:) = sum(bsxfun(@minus, mean_cur(3:5,:), dataPts(3:5,:)).^ 2);
        kernel_range_datapoint_index = find(squ_Euclidean_distance(1,:) < bandSq(1, 1));% points within bandWidth
        kernel_range_datapoint_index = find(squ_Euclidean_distance(2,:) < bandSq(1, 2));
         cluster_mem(kernel_range_datapoint_index) = cluster_mem(kernel_range_datapoint_index) + 1;
        mean_previous = mean_cur; % save the old mean
         mean_cur = gaussian_kernel(dataPts(:,kernel_range_datapoint_index),sqrt(squ_Euclidean_distance(1, kernel_range_datapoint_index)),sqrt(squ_Euclidean_distance(2, kernel_range_datapoint_index)),bandwidth); % compute the new mean


        cluster_members = [cluster_members kernel_range_datapoint_index]; % add any point within bandWidth to the cluster
        tracking_array(cluster_members) = true; % mark that these points have been visited
        % converging condition
        if norm(mean_cur - mean_previous) < threshold_convergence
            join_cluster = 0;
            for cno = 1:no_cluster
                dist1 = norm(mean_cur(1:2) - clustCent(1:2, cno)); % spatial
                dist2 = norm(mean_cur(3:5) - clustCent(3:5, cno)); % range
                if (dist1 < bandwidth(1, 1) && dist2 < bandwidth(1, 2)) % condition to join the kernel
                    join_cluster = cno;
            break;
            end
        end


            if join_cluster > 0
                nc = numel(cluster_members);
            no = numel(clustMembsCell{ join_cluster});
            nw = [nc; no]/ (nc + no);
            clustMembsCell{ join_cluster} = unique([clustMembsCell{ join_cluster},cluster_members]);
            clustCent(:, join_cluster) = mean_cur * nw(1) + mean_previous * nw(2);
            clusterV(join_cluster,:) = clusterV(join_cluster,:) + cluster_mem;
            else 
                no_cluster = no_cluster + 1;
            clustCent(:, no_cluster) = mean_cur;
            clustMembsCell{ no_cluster} = cluster_members;
            clusterV(no_cluster,:) = cluster_mem;
            end
            break;
            end
        end
    dataset_index = find(~tracking_array);
            no_point_4_initial = length(dataset_index);
            end
            [~, data2cluster] = max(clusterV,[], 1);
            if nargout > 2
                cluster2dataCell = cell(no_cluster, 1);
            for cno = 1:no_cluster
        
                cluster_members = find(data2cluster == cno);
                cluster2dataCell{ cno} = cluster_members;
            end
        end

end
        }
    }
}
