using Accord.Controls;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics;
using Accord.Statistics.Kernels;
using RoadScanner.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    class Program
    {
        static void Main(string[] args)
        {
            MLService service=new MLService();
            var inputs =  service.GetAllSegmentChain3().Select(sc => new double[] {sc.speedAvg1.Value,sc.speedAvg2.Value,sc.speedAvg3.Value }).ToArray();
            var outputs = service.GetAllSegmentChain3().Select(sc =>  sc.ContainAnomaly ).ToArray();

            var smo = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 100 // Create a hard-margin SVM 
            };

            // Use the algorithm to learn the svm
            var svm = smo.Learn(inputs, outputs);

            bool[] prediction = svm.Decide(inputs);

            // Compute the classification error between the expected 
            // values and the values actually predicted by the machine:
            double error = new AccuracyLoss(outputs).Loss(prediction);

            Console.WriteLine("Error: " + error);

            // Show results on screen 
            //ScatterplotBox.Show("Training data", inputs, outputs);
            //ScatterplotBox.Show("SVM results", inputs, prediction.ToZeroOne());

            Console.ReadKey();

        }
    }
}
