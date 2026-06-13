using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_ZA.Machine_Learning;
using Microsoft.ML;

namespace AI_ZA.Services
{
    public class MLIntentClassifier
    {
        private readonly PredictionEngine<IntentData, IntentPrediction> predictor;

        public MLIntentClassifier()
        {
            MLContext mlContext = new MLContext();

            /*  IDataView data =
                  mlContext.Data.LoadFromTextFile<IntentData>(
                      "Data/intent_data.csv",
                      separatorChar: ',',
                      hasHeader: false);
            */

            IDataView data =
         mlContext.Data.LoadFromTextFile<IntentData>(
        System.IO.Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Data",
            "intent_data.csv"),
        separatorChar: ',',
        hasHeader: false);

            var pipeline =
                mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Text.FeaturizeText(
                    "Features",
                    nameof(IntentData.Text)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);

            predictor =
                mlContext.Model.CreatePredictionEngine
                <IntentData, IntentPrediction>(model);
        }

        public string PredictIntent(string text)
        {
            var prediction = predictor.Predict(
                new IntentData
                {
                    Text = text
                });

            return prediction.PredictedLabel;
        }
    }
}