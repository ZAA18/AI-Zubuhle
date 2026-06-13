using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace AI_ZA.Machine_Learning
{
    public class IntentPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabel { get; set; }
    }
}
