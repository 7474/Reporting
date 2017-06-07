using System;
using System.Collections.Generic;
using System.IO;
using App.Metrics.Tagging;

namespace AppMetrics.Reporters.Sandbox.CustomMetricConsoleFormatting
{
    public class CustomMetricPoint
    {
        public CustomMetricPoint(
            string measurement,
            IReadOnlyDictionary<string, object> fields,
            MetricTags tags)
        {
            Measurement = measurement;
            Fields = fields;
            Tags = tags;
        }

        public IReadOnlyDictionary<string, object> Fields { get; }

        public string Measurement { get; }

        public MetricTags Tags { get; }

        public void Format(TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            textWriter.Write((string)Measurement);

            if (Tags.Count > 0)
            {
                for (var i = 0; i < Tags.Count; i++)
                {
                    textWriter.Write(' ');
                    textWriter.Write($"{Tags.Keys[i] = Tags.Values[i]}");
                }
            }

            foreach (var f in Fields)
            {
                textWriter.Write($"{f.Key} = {f.Value}");
            }
        }
    }
}