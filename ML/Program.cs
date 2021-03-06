﻿using Accord.Controls;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.MachineLearning.Performance;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics;
using Accord.Statistics.Analysis;
using Accord.Statistics.Filters;
using Accord.Statistics.Kernels;
using Accord.Statistics.Models.Regression.Linear;
using RoadScanner.Entities;
using RoadScanner.Entities.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    class Program
    {
        static string AnomalyDetectionModelFileName = "AnomalyDetectionModel.txt";
        static string AnomalyClassificationModelFileName = "AnomalyClassificationModel.txt";
        static string AnomalyClassifierBySeverityModelFileName = "AnomalyClassifierBySeverityModelFileName.txt";



        static void Main(string[] args)
        {
            //trainAnomalyDetectionModel();
           // trainAnomalyClassifierModel();

            //detectAnomalies();


            //trainAnomalyDetectionMultiClassModel();
            //trainAnomalyDetectionTwoClassModel();

            trainSeverityModel();


        }

        static void trainAnomalyDetectionModel()
        {
            MLService service = new MLService();
            //var chain = service.GetAllSegments_SegmentChain3();
            //var chain = service.GetAllSegments_SegmentChain4();
            //var chain = service.GetAllSegments_SegmentChain5();
            //var chain = service.GetAllSegments_SegmentChain6();
            //var chain = service.GetAllSegments_SegmentChain4_HighSampleCount();
            //var chain = service.GetAllSegments_SegmentChain5_Top28();
            //var chain = service.GetAllSegments_SpeedDifference_SegmentChain5_Minimized();
            //var chain = service.GetAllSegments_SegmentChain6_Rounded();
            //var chain = service.GetAllSegments_SegmentChain6_AnomalySpreaded();
            //var chain = service.GetAllSegments_SegmentChain6_AnomalySpreaded();
            var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded();
            // var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded().Where(t => t.AnomalyType == 1 || t.AnomalyType == 2);
            //var chain = service.GetAllSegments_SpeedDifference_SegmentChain5();
            //var chain = service.GetAllSegments_HighSamplesCount_SegmentChain5();

            //double[][] test  = chain1.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.speedVar4.Value, sc.speedVar5.Value, sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value, sc.VarSpentTime1.Value, sc.VarSpentTime2.Value, sc.VarSpentTime3.Value, sc.VarSpentTime4.Value, sc.VarSpentTime5.Value, }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value,sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.VarSpentTime1.Value, sc.VarSpentTime2.Value, sc.VarSpentTime3.Value}).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.speedVar4.Value, sc.speedVar5.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.VarSpentTime1.Value, sc.VarSpentTime2.Value, sc.VarSpentTime3.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value,    sc.AvgSpentTime4.Value}).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.speedVar4.Value, sc.speedVar5.Value,sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value, sc.VarSpentTime1.Value, sc.VarSpentTime2.Value, sc.VarSpentTime3.Value, sc.VarSpentTime4.Value, sc.VarSpentTime5.Value, }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value, sc.speedAvg6.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.speedVar4.Value, sc.speedVar5.Value, sc.speedVar6.Value, sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value, sc.AvgSpentTime6.Value, sc.VarSpentTime1.Value, sc.VarSpentTime2.Value, sc.VarSpentTime3.Value, sc.VarSpentTime4.Value, sc.VarSpentTime5.Value, sc.VarSpentTime6.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.speedVar4.Value, sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.VarSpentTime1.Value, sc.VarSpentTime2.Value, sc.VarSpentTime3.Value }).ToArray();
            // double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedVar1.Value, sc.speedVar2.Value, sc.speedVar3.Value, sc.speedVar4.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value, sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value}).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.speedAvg1.Value, sc.speedAvg2.Value, sc.speedAvg3.Value, sc.speedAvg4.Value, sc.speedAvg5.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.SpeedDiff1.Value, sc.SpeedDiff2.Value, sc.SpeedDiff3.Value, sc.SpeedDiff4.Value,sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.SpeedDiff1.Value, sc.SpeedDiff2.Value, sc.SpeedDiff3.Value, sc.SpeedDiff4.Value,sc.AvgSpentTime1.Value, sc.AvgSpentTime2.Value, sc.AvgSpentTime3.Value, sc.AvgSpentTime4.Value, sc.AvgSpentTime5.Value }).ToArray();
            //double[][] inputs = chain.Select(sc => new double[] { sc.SpeedDiff1.Value, sc.SpeedDiff2.Value,sc.AvgTime.Value,sc.speedAvg4.Value }).ToArray();

            double[][] inputs = chain.Select(sc => new double[] { sc.MaxSpeed.Value, sc.MinSpeed.Value, sc.SpeedRange.Value, sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value, sc.MaxTimeVar.Value, sc.MinTimeVar.Value, sc.TimeVarRange.Value }).ToArray();  //  
                                                                                                                                                                                                                                                                                                                                                            //double[][] inputs = chain.Select(sc => new double[] { sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value }).ToArray();  //  

            int[] outputs = chain.Select(sc => sc.ContainAnomaly).ToArray();
            //int[] outputs = chain.Select(sc => sc.AnomalyType).ToArray();

            //double[][] inputs0 = chain.Where(sc => sc.ContainAnomaly == 0).Select(sc => new double[] { sc.SpeedDiff1.Value, sc.SpeedDiff2.Value }).ToArray();
            //int[] outputs0 = chain.Where(sc => sc.ContainAnomaly == 0).Select(sc => sc.ContainAnomaly).ToArray();


            //double[][] inputs1 = chain.Where(sc => sc.ContainAnomaly == 1).Select(sc => new double[] { sc.SpeedDiff1.Value, sc.SpeedDiff2.Value }).ToArray();
            //int[] outputs1 = chain.Where(sc => sc.ContainAnomaly == 1).Select(sc => sc.ContainAnomaly).ToArray();

            //double[][] inputs2 = chain.Where(sc => sc.ContainAnomaly == 0).Select(sc => new double[] { sc.SpeedDiff1.Value, sc.AvgTime.Value }).ToArray();
            //int[] outputs2 = chain.Where(sc => sc.ContainAnomaly == 0).Select(sc => sc.ContainAnomaly).ToArray();

            //double[][] inputs3= chain.Where(sc => sc.ContainAnomaly == 1).Select(sc => new double[] { sc.SpeedDiff1.Value, sc.AvgTime.Value }).ToArray();
            //int[] outputs3= chain.Where(sc => sc.ContainAnomaly == 1).Select(sc => sc.ContainAnomaly).ToArray();

            //SVM_crossValidation(inputs, outputs);

            SVM_TrainAnomalyDetectionModel(inputs, outputs);
            //SVM_crossValidation_AnomalyDetection(inputs, outputs);

            //DecisionTree_crossValidation(inputs, outputs);
            //GridSearch(inputs, outputs);

            //var pca = new PrincipalComponentAnalysis()
            //{
            //    Method = PrincipalComponentMethod.Center,
            //    Whiten = true
            //};

            //// Now we can learn the linear projection from the data
            //MultivariateLinearRegression transform = pca.Learn(inputs);
            //pca.NumberOfOutputs = 3;
            //// Finally, we can project all the data
            //double[][] output1 = pca.Transform(inputs);

            //SVM_crossValidation(inputs, outputs);
            //// Or just its first components by setting 
            //// NumberOfOutputs to the desired components:


            //// And then calling transform again:
            //double[][] output2 = pca.Transform(inputs);

            //// We can also limit to 80% of explained variance:
            //pca.ExplainedVariance = 0.8;

            //// And then call transform again:
            //double[][] output3 = pca.Transform(inputs);


            //// Create a new K-Means algorithm
            //KMeans kmeans = new KMeans(k: 2);
            ////kmeans.Centroids = new double [2][];
            ////kmeans.Centroids[0] = new double[] {-2.76384235537843, 0.608515794829327 };
            ////kmeans.Centroids[1] = new double[] {-0.579246221664498,0.121793585323178};
            //// Compute and retrieve the data centroids
            //var clusters = kmeans.Learn(inputs);



            //// Use the centroids to parition all the data
            //int[] labels = clusters.Decide(inputs);
            //var zeros = labels.Where(l => l == 0).ToList();
            //var ones = labels.Where(l => l == 1).ToList();
            //var twos = labels.Where(l => l == 2).ToList();
            //var threes = labels.Where(l => l == 3).ToList();

            //int truleyLabeledAnomalies = 0;
            //for (int i = 0; i < chain.Count; i++)
            //{
            //    if (chain.ElementAt(i).ContainAnomaly == 1 && labels.ElementAt(i) == 1)
            //    {
            //        truleyLabeledAnomalies += 1;
            //    }
            //}

            //Console.WriteLine(truleyLabeledAnomalies);

            //var smo = new SequentialMinimalOptimization<Linear>()
            //{
            //    Complexity = 0.000001,
            //    Kernel = new Linear()
            //};

            //// Use the algorithm to learn the svm
            //var svm = smo.Learn(inputs, outputs);

            //// bool pred = svm.Decide(new double[] { 2.49922336915495, 2.38719486132452, 2.59047776529037, 1.94322311520282, 2.32949533880782, 1.53491343472098, 0.0611354785139238, 0.848698199040911, 0.85367931112144, 0.887108397987341, 2, 2.66666666666667, 2, 2.54545454545455, 3, 1.33333333333333, 0, 0.672727272727273, 0.75, 0 });
            ////bool pred = svm.Decide(new double[] { 3.6668832456934,2.72565059380599,3.4617494242872,4.15125345320445,1.07290177209667,4.02676082352871,0.157250607457867,0.00245768485574516,8.51233980164814,1.2701659036119,2,2,2,10,2.33333333333333,0,0 ,0,128,0.333333333333334});

            ////bool pred = svm.Decide(new double[] {0.342804868030116,0.971802788698728,3.87391319346965, 0.0486282126059593,2.94649397465733,0.547271634138705, 0 ,4.34382476637454 , 0.00508098235164243,1.13588971473715,2,2,1.75 ,28 ,1 , 1 , 0 , 0.25 , 1352 , 0 });
            //bool[] prediction = svm.Decide(test);
            //// Compute the classification error between the expected 
            //// values and the values actually predicted by the machine:
            //double error = new AccuracyLoss(outputs).Loss(prediction);

            //Console.WriteLine("Error: " + error);

            //Show results on screen
            //ScatterplotBox.Show("not anomaly speed", inputs0, outputs0);
            //ScatterplotBox.Show("anomaly speed", inputs1, outputs1);
            //ScatterplotBox.Show("not anomaly time", inputs2, outputs2);
            //ScatterplotBox.Show("anomaly time ", inputs3, outputs3);
            //ScatterplotBox.Show("SVM results", inputs, prediction.ToZeroOne());

            Console.ReadKey();

        }

        static void trainAnomalyClassifierModel()
        {
            MLService service = new MLService();

            var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded_OnlyANomaly().ToList();

            double[][] inputs = chain.Select(sc => new double[] { sc.MaxSpeed.Value, sc.MinSpeed.Value, sc.SpeedRange.Value, sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value, sc.MaxTimeVar.Value, sc.MinTimeVar.Value, sc.TimeVarRange.Value }).ToArray();  //  

            int[] outputs = chain.Select(sc => sc.AnomalyType).ToArray();

            //SVM_TrainAnomalyClassificationModel(inputs, outputs);
            SVM_crossValidation_AnomalyClassifier(inputs, outputs);
            Console.ReadKey();

        }

        static void detectAnomalies()
        {
            var anomalyDetectionModel=Serializer.Load<SupportVectorMachine<Gaussian>>(AnomalyDetectionModelFileName);
            var anomalyClassificationModel = Serializer.Load<SupportVectorMachine<Gaussian>>(AnomalyClassificationModelFileName);

            MLService service = new MLService();
            SegmentService serviceService = new SegmentService();

            var chains = service.GetAllSegments_SegmentChain7_AnomalySpreaded();

            int numberOfAnomalies =0;
            int numberOfPotholes = 0;
            foreach (var chain in chains)
            {
                double[] inputs = new double[] { chain.MaxSpeed.Value, chain.MinSpeed.Value, chain.SpeedRange.Value, chain.TotalTime.Value, chain.MinTime.Value, chain.MaxTime.Value, chain.TimeRange.Value, chain.MaxSpeedVar.Value, chain.MinSpeedVar.Value, chain.SpeedVarRange.Value, chain.MaxTimeVar.Value, chain.MinTimeVar.Value, chain.TimeVarRange.Value };
                bool isContainAnomaly = anomalyDetectionModel.Decide(inputs);
                bool isPothole = false;
                if (isContainAnomaly)
                {
                    numberOfAnomalies++;

                    isPothole = anomalyClassificationModel.Decide(inputs);
                    if (isPothole)
                        numberOfPotholes++;

                    SegmentChain sc = new SegmentChain() {
                        Segment1Id = chain.Segment1Id,
                        Segment2Id = chain.Segment2Id,
                        Segment3Id = chain.Segment3Id,
                        Segment4Id = chain.Segment4Id,
                        Segment5Id = chain.Segment5Id,
                        Segment6Id = chain.Segment6Id,
                        Segment7Id = chain.Segment7Id,
                        PredictedAnomalyType = (short)(isContainAnomaly? (isPothole?2:1):0),
                        CreationDate = DateTime.Now
                    };
                    serviceService.CreateSegmentChain(sc);
                }
                
            }
        }

        static void trainSeverityModel()
        {
            MLService service = new MLService();
            var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded_OnlyANomaly();
            double[][] inputs = chain.Select(sc => new double[] { sc.MaxSpeedChange.Value, sc.MinSpeedChange.Value }).ToArray();  //  

            KMeans kmeans = new KMeans(k: 3);
            //kmeans.Centroids = new double [2][];
            //kmeans.Centroids[0] = new double[] {-2.76384235537843, 0.608515794829327 };
            //kmeans.Centroids[1] = new double[] {-0.579246221664498,0.121793585323178};
            // Compute and retrieve the data centroids
            var clusters = kmeans.Learn(inputs);
            Serializer.Save(clusters, AnomalyClassifierBySeverityModelFileName);


            // Use the centroids to parition all the data
            int[] labels = clusters.Decide(inputs);
            var zeros = labels.Where(l => l == 0).ToList();
            var ones = labels.Where(l => l == 1).ToList();
            var twos = labels.Where(l => l == 2).ToList();

            ScatterplotBox.Show("Severity Clusters", inputs,labels);



        }

        static void trainAnomalyDetectionMultiClassModel()
        {
            MLService service = new MLService();

            var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded_All();

            double[][] inputs = chain.Select(sc => new double[] { sc.MaxSpeed.Value, sc.MinSpeed.Value, sc.SpeedRange.Value, sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value, sc.MaxTimeVar.Value, sc.MinTimeVar.Value, sc.TimeVarRange.Value }).ToArray();  //  
                                                                                                                                                                                                                                                                                                                                                            //double[][] inputs = chain.Select(sc => new double[] { sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value }).ToArray();  //  

            int[] outputs = chain.Select(sc => sc.AnomalyType).ToArray();

            //SVM_crossValidation_AnomalyDetection(inputs, outputs);
            trainMultiClass(inputs, outputs);

            Console.ReadKey();

        }

        static void trainAnomalyDetectionTwoClassModel()
        {
            MLService service = new MLService();

            var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded_All();

            double[][] inputs = chain.Select(sc => new double[] { sc.MaxSpeed.Value, sc.MinSpeed.Value, sc.SpeedRange.Value, sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value, sc.MaxTimeVar.Value, sc.MinTimeVar.Value, sc.TimeVarRange.Value }).ToArray();  //  
                                                                                                                                                                                                                                                                                                                                                            //double[][] inputs = chain.Select(sc => new double[] { sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value }).ToArray();  //  

            int[] outputs = chain.Select(sc => sc.ContainAnomaly).ToArray();

            //SVM_crossValidation_AnomalyDetection(inputs, outputs);
            trainTwoClass(inputs, outputs);

            Console.ReadKey();

        }

        static void trainMultiClass(double[][] inputs, int[] outputs)
        {

            var splitset = new SplitSetValidation<MulticlassSupportVectorMachine<Gaussian, double[]>, double[]>()
            {
                Learner = (s) => new MulticlassSupportVectorLearning<Gaussian, double[]>()
                {
                    Learner = (m) => new SequentialMinimalOptimization<Gaussian, double[]>()
                    {
                        Complexity = 10,
                        Kernel = new Gaussian(3)
                    }

                }
            };

            // Create the multi-class learning algorithm for the machine
            //var teacher = new MulticlassSupportVectorLearning<Gaussian>()
            //{
            //    // Configure the learning algorithm to use SMO to train the
            //    //  underlying SVMs in each of the binary class subproblems.
            //    Learner = (param) => new SequentialMinimalOptimization<Gaussian>()
            //    {
            //        Complexity = 10,
            //        Kernel = new Gaussian(3)
            //        // Estimate a suitable guess for the Gaussian kernel's parameters.
            //        // This estimate can serve as a starting point for a grid search.
            //        //UseKernelEstimation = true
            //    }
            //};

            // The following line is only needed to ensure reproducible results. Please remove it to enable full parallelization
            //teacher.ParallelOptions.MaxDegreeOfParallelism = 1; // (Remove, comment, or change this line to enable full parallelism)

            // Learn a machine
            //var machine = teacher.Learn(inputs, outputs);
            // Obtain class predictions for each sample
            //int[] predicted = machine.Decide(inputs);

            //splitset.ParallelOptions.MaxDegreeOfParallelism = 1;
            var machine = splitset.Learn(inputs, outputs);

            int[] predicted = machine.Model.Decide(inputs);

            //var value1 = machine.Training.Value;
            //var value2 = machine.Validation.Value;
            //int[] predicted = machine.Decide(inputs);


            // Get class scores for each sample
            double[] scores = machine.Model.Score(inputs);

            //Compute classification error
            double error = new ZeroOneLoss(outputs).Loss(predicted);
        }

        static void trainTwoClass(double[][] inputs, int[] outputs)
        {



            var teacher = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 10,
                Kernel = new Gaussian(3)
                // Estimate a suitable guess for the Gaussian kernel's parameters.
                // This estimate can serve as a starting point for a grid search.
                //UseKernelEstimation = true
            };



            // Learn a machine
            var machine = teacher.Learn(inputs, outputs);


            bool[] predicted = machine.Decide(inputs);



            // Get class scores for each sample
            double[] scores = machine.Score(inputs);

            // Compute classification error
            double error = new ZeroOneLoss(outputs).Loss(predicted);
        }

       

        static void trainAnomalyDetecorDTModel()
        {
            MLService service = new MLService();

            var chain = service.GetAllSegments_SegmentChain7_AnomalySpreaded_OnlyANomaly().ToList();

            double[][] inputs = chain.Select(sc => new double[] { sc.MaxSpeed.Value, sc.MinSpeed.Value, sc.SpeedRange.Value, sc.TotalTime.Value, sc.MinTime.Value, sc.MaxTime.Value, sc.TimeRange.Value, sc.MaxSpeedVar.Value, sc.MinSpeedVar.Value, sc.SpeedVarRange.Value, sc.MaxTimeVar.Value, sc.MinTimeVar.Value, sc.TimeVarRange.Value }).ToArray();  //  

            int[] outputs = chain.Select(sc => sc.AnomalyType).ToArray();

            DecisionTree_crossValidation(inputs, outputs);

            Console.ReadKey();

        }

        //    public static void NaiveBaise(double[][] chain)
        //    {

        //        DataTable data = new DataTable("dataa");
        //        data.Rows.Add()
        //        data.Columns.AddRange( "speedAvg1", "speedAvg2", "speedAvg3", "speedAvg4", "speedAvg5", "speedAvg6", "ContainAnomaly");

        //        Codification codebook = new Codification(data,
        //"speedAvg1", "speedAvg2", "speedAvg3", "speedAvg4", "speedAvg5", "speedAvg6", "ContainAnomaly");

        //        // Extract input and output pairs to train
        //        DataTable symbols = codebook.Apply(data);
        //        int[][] inputs = symbols.ToArray<int>("Outlook", "Temperature", "Humidity", "Wind");
        //        int[] outputs = symbols.ToArray<int>("PlayTennis");

        //    }
        public static void SVM_crossValidation_AnomalyDetection(double[][] inputs, int[] outputs)
        {
            Accord.Math.Random.Generator.Seed = 0;
            var crossvalidation = new CrossValidation<SupportVectorMachine<Gaussian, double[]>, double[]>()
            {
                K = 100, // Use 3 folds in cross-validation

                // Indicate how learning algorithms for the models should be created



                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 10,
                //    Kernel = new Gaussian(0.5)

                //},

                //if ssegments beside hyper removed
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 100,
                //    Kernel = new Gaussian(1) 

                //},

                //with max and min speed variance
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 100,
                //    Kernel = new Gaussian(1.55)

                //},

                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 15,
                //    Kernel = new Gaussian(1.55)

                //},
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 7,
                //    Kernel = new Gaussian(1.9)

                //},

                //best results for 7 segments witrh fields :sc.MaxSpeed.Value, sc.MinSpeed.Value, sc.SpeedRange.Value, sc.TotalTime.Value,sc.MinTime.Value,sc.MaxTime.Value, sc.TimeRange.Value,sc.MaxSpeedVar.Value,sc.MinSpeedVar.Value, sc.SpeedVarRange.Value
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 7,
                //    Kernel = new Gaussian(2.4)

                //},
                //Best of the best
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 7,
                //    Kernel = new Gaussian(2.4)

                //},

                //for Roadscanner DB
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 10,
                //    Kernel = new Gaussian(2.92)

                //},

                //for Roadscanner3 DB
                //without pothole
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 10,
                //    Kernel = new Gaussian(2.1)

                //},

                //for Roadscanner3 DB
                //with pothole
                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 15,
                //    Kernel = new Gaussian(2.5)

                //},

                //RoadScanner3 Db
                //with pothole
                //
                Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                {
                    Complexity = 15,
                    Kernel = new Gaussian(3)

                },

                // Indicate how the performance of those models will be measured
                Loss = (expected, actual, p) => new ZeroOneLoss(expected).Loss(actual),

                Stratify = true, //   force balancing of classes
            };

            // If needed, control the parallelization degree
            crossvalidation.ParallelOptions.MaxDegreeOfParallelism = 1;

            // Compute the cross-validation
            var result = crossvalidation.Learn(inputs, outputs);


            // Finally, access the measured performance.
            double trainingErrors = result.Training.Mean;
            double validationErrors = result.Validation.Mean;

            // If desired, compute an aggregate confusion matrix for the validation sets:
            GeneralConfusionMatrix gcm = result.ToConfusionMatrix(inputs, outputs);
            double accuracy = gcm.Accuracy;
            double error = gcm.Error;


            Console.WriteLine("Accuracy:" + gcm.Accuracy);
            Console.WriteLine("Error:" + gcm.Error);

            Console.WriteLine("Not Anomaly Precision:" + gcm.Precision[0]);
            Console.WriteLine("Not Anomaly Recall:" + gcm.Recall[0]);
            Console.WriteLine("Anomaly Precision:" + gcm.Precision[1]);
            Console.WriteLine("Anomaly Recall:" + gcm.Recall[1]);

            //double anomalyFScore = 2 * (gcm.Precision[1] * gcm.Recall[1]) / (gcm.Precision[1] + gcm.Recall[1]);
            //double NotAnomalyFScore = 2 * (gcm.Precision[0] * gcm.Recall[0]) / (gcm.Precision[0] + gcm.Recall[0]);
            //Console.WriteLine("Not ANomaly F-score:" + NotAnomalyFScore);
            //Console.WriteLine("Anomaly F-score:" + anomalyFScore);

            Console.WriteLine("Not ANomaly F-score:" + gcm.PerClassMatrices[0].FScore);
            Console.WriteLine("Anomaly F-score:" + gcm.PerClassMatrices[1].FScore);

        }


        public static void SVM_TrainAnomalyDetectionModel(double[][] inputs, int[] outputs)
        {
            var learn = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 15,
                Kernel = new Gaussian(3)
            };

            SupportVectorMachine<Gaussian> svm = learn.Learn(inputs, outputs);
            Serializer.Save(svm, AnomalyDetectionModelFileName);
        }


        public static void SVM_crossValidation_AnomalyClassifier(double[][] inputs, int[] outputs)
        {
            Accord.Math.Random.Generator.Seed = 0;
            var crossvalidation = new CrossValidation<SupportVectorMachine<Gaussian, double[]>, double[]>()
            {
                K = 10, // Use 3 folds in cross-validation

                //Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                //{
                //    Complexity = 10,
                //    Kernel = new Gaussian(3)

                //},
                Learner = (s) => new SequentialMinimalOptimization<Gaussian, double[]>()
                {
                    Complexity = 10,
                    Kernel = new Gaussian(2.6)

                },

                // Indicate how the performance of those models will be measured
                Loss = (expected, actual, p) => new ZeroOneLoss(expected).Loss(actual),

                Stratify = true, //   force balancing of classes
            };

            // If needed, control the parallelization degree
            crossvalidation.ParallelOptions.MaxDegreeOfParallelism = 1;

            // Compute the cross-validation
            var result = crossvalidation.Learn(inputs, outputs);


            // Finally, access the measured performance.
            double trainingErrors = result.Training.Mean;
            double validationErrors = result.Validation.Mean;

            // If desired, compute an aggregate confusion matrix for the validation sets:
            GeneralConfusionMatrix gcm = result.ToConfusionMatrix(inputs, outputs);
            double accuracy = gcm.Accuracy;
            double error = gcm.Error;


            Console.WriteLine("Accuracy:" + gcm.Accuracy);
            Console.WriteLine("Error:" + gcm.Error);

            Console.WriteLine("First Anomaly type Precision:" + gcm.Precision[0]);
            Console.WriteLine("First Anomaly type  Recall:" + gcm.Recall[0]);
            Console.WriteLine("Second Anomaly type  Precision:" + gcm.Precision[1]);
            Console.WriteLine("Second Anomaly type  Recall:" + gcm.Recall[1]);

            //double anomalyFScore = 2 * (gcm.Precision[1] * gcm.Recall[1]) / (gcm.Precision[1] + gcm.Recall[1]);
            //double NotAnomalyFScore = 2 * (gcm.Precision[0] * gcm.Recall[0]) / (gcm.Precision[0] + gcm.Recall[0]);
            //Console.WriteLine("Not ANomaly F-score:" + NotAnomalyFScore);
            //Console.WriteLine("Anomaly F-score:" + anomalyFScore);

            Console.WriteLine("First Anomaly type F-score:" + gcm.PerClassMatrices[0].FScore);
            Console.WriteLine("Second Anomaly type  F-score:" + gcm.PerClassMatrices[1].FScore);


            //var splitset = new SplitSetValidation<MulticlassSupportVectorMachine<Gaussian, double[]>, double[]>()
            //{

            //    Learner = (s) => new MulticlassSupportVectorLearning<Gaussian, double[]>()
            //    {

            //        Learner = (m) => new SequentialMinimalOptimization<Gaussian, double[]>()
            //        {
            //            Complexity = 10,
            //            Kernel = new Gaussian(2.92)
            //        }
            //    }
            //    ,Stratify =true
            //};

            //var result = splitset.Learn(inputs, outputs);

            //double trainingErrors = result.Training.Value; 
            //double validationErrors = result.Validation.Value;

        }


        public static void SVM_TrainAnomalyClassificationModel(double[][] inputs, int[] outputs)
        {
            var learn = new SequentialMinimalOptimization<Gaussian>()
            {
                //Complexity = 50,
                //Kernel = new Gaussian(2.55)
                Complexity = 10,
                Kernel = new Gaussian(2.6)
            };

            SupportVectorMachine<Gaussian> svm = learn.Learn(inputs, outputs);
            Serializer.Save(svm, AnomalyClassificationModelFileName);
        }


        public static void DecisionTree_crossValidation(double[][] inputs, int[] outputs)
        {
            // Ensure we have reproducible results
            Accord.Math.Random.Generator.Seed = 0;



            // Let's say we want to measure the cross-validation performance of
            // a decision tree with a maximum tree height of 5 and where variables
            // are able to join the decision path at most 2 times during evaluation:
            var cv = CrossValidation.Create(

                k: 10, // We will be using 10-fold cross validation

                learner: (p) => new C45Learning() // here we create the learning algorithm
                {
                    Join = 2,
                    MaxHeight = 5
                },

                // Now we have to specify how the tree performance should be measured:
                loss: (actual, expected, p) => new ZeroOneLoss(expected).Loss(actual),

                // This function can be used to perform any special
                // operations before the actual learning is done, but
                // here we will just leave it as simple as it can be:
                fit: (teacher, x, y, w) => teacher.Learn(x, y, w),

                // Finally, we have to pass the input and output data
                // that will be used in cross-validation. 
                x: inputs, y: outputs
            );

            // After the cross-validation object has been created,
            // we can call its .Learn method with the input and 
            // output data that will be partitioned into the folds:
            var result = cv.Learn(inputs, outputs);

            // We can grab some information about the problem:
            int numberOfSamples = result.NumberOfSamples; // should be 569
            int numberOfInputs = result.NumberOfInputs;   // should be 30
            int numberOfOutputs = result.NumberOfOutputs; // should be 2

            double trainingError = result.Training.Mean; // should be 0.017771153143274855
            double validationError = result.Validation.Mean; // should be 0.0755952380952381

            // If desired, compute an aggregate confusion matrix for the validation sets:
            GeneralConfusionMatrix gcm = result.ToConfusionMatrix(inputs, outputs);
            double accuracy = gcm.Accuracy; // result should be 0.92442882249560632

            Console.WriteLine("Accuracy:" + gcm.Accuracy);
            Console.WriteLine("Error:" + gcm.Error);

            Console.WriteLine("Not Anomaly Precision:" + gcm.Precision[0]);
            Console.WriteLine("Not Anomaly Recall:" + gcm.Recall[0]);
            Console.WriteLine("Anomaly Precision:" + gcm.Precision[1]);
            Console.WriteLine("Anomaly Recall:" + gcm.Recall[1]);

            double anomalyFScore = 2 * (gcm.Precision[1] * gcm.Recall[1]) / (gcm.Precision[1] + gcm.Recall[1]);
            double NotAnomalyFScore = 2 * (gcm.Precision[0] * gcm.Recall[0]) / (gcm.Precision[0] + gcm.Recall[0]);
            Console.WriteLine("Not ANomaly F-score:" + NotAnomalyFScore);
            Console.WriteLine("Anomaly F-score:" + anomalyFScore);
        }

        public static void GridSearch(double[][] inputs, int[] outputs)
        {
            GridSearchRange[] ranges =
{
    new GridSearchRange("complexity", new double[] { 0.00000001,0.001, 5.20, 0.30, 0.50,20,50,100,100 } ),
    new GridSearchRange("degree",     new double[] { 1, 2, 3, 4, 5, 10 } ),
    new GridSearchRange("constant",   new double[] { 0, 1, 2 } ),
    new GridSearchRange("sigma",   new double[] { 0.1,0.25,0.5, 1, 2,5 } )

};


            // Instantiate a new Grid Search algorithm for Kernel Support Vector Machines
            var gridsearch = new GridSearch<KernelSupportVectorMachine>(ranges);

            // Set the fitting function for the algorithm
            gridsearch.Fitting = delegate (GridSearchParameterCollection parameters, out double error)
            {
                // The parameters to be tried will be passed as a function parameter.
                int degree = (int)parameters["degree"].Value;
                double constant = parameters["constant"].Value;
                double complexity = parameters["complexity"].Value;
                double sigma = parameters["sigma"].Value;
                // Use the parameters to build the SVM model
                //Polynomial kernel = new Polynomial(degree, constant);
                //Gaussian kernel = new Gaussian(sigma);
                Gaussian kernel = new Gaussian(sigma);
                KernelSupportVectorMachine ksvm = new KernelSupportVectorMachine(kernel, 2);

                // Create a new learning algorithm for SVMs
                SequentialMinimalOptimization smo = new SequentialMinimalOptimization(ksvm, inputs, outputs);
                smo.Complexity = complexity;

                // Measure the model performance to return as an out parameter
                error = smo.Run();

                return ksvm; // Return the current model
            };


            // Declare some out variables to pass to the grid search algorithm
            GridSearchParameterCollection bestParameters; double minError;

            // Compute the grid search to find the best Support Vector Machine
            KernelSupportVectorMachine bestModel = gridsearch.Compute(out bestParameters, out minError);
        }

    }
}
