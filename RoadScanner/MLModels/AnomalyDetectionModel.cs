using Accord.IO;
using Accord.MachineLearning.VectorMachines;
using Accord.Statistics.Kernels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoadScanner.MLModels
{
    public class AnomalyDetectionModel
    {
        public static string AnomalyDetectionModelPath { get { return "MLModels\\TrainedModels\\AnomalyDetectionModel.txt"; } }
        private static SupportVectorMachine<Gaussian> _model;
        public static SupportVectorMachine<Gaussian> Model {
            get {
                if (_model == null)
                {
                    _model = Serializer.Load<SupportVectorMachine<Gaussian>>(AnomalyDetectionModelPath);
                }

                return _model;
            } 
        }

        //static List<> Predict()
        //{
        //}
    }
}