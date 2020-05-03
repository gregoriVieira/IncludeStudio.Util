using IncludeStudio.Util.Domain.Data;
using IncludeStudio.Util.Domain.Entities;
using IncludeStudio.Util.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IncludeStudio.Util.Radar
{
    public static class Logger
    {

        /// <summary>
        /// Start the current map of execution steps , 
        /// don't need to pass the fileName !
        /// </summary>
        /// <param name="authKey"></param>
        /// <param name="baseUrl"></param>
        /// <param name="jsonPath"></param>
        /// <param name="description"></param>
        /// <param name="fileName"></param>
        public static void StartRadar(string authKey, string baseUrl, string jsonPath, string description, [CallerFilePath] string fileName = null)
        {
            if (string.IsNullOrEmpty(authKey))
                throw new Exception("authKey cannot be null");

            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("baseUrl cannot be null");

            if (string.IsNullOrEmpty(jsonPath))
                throw new Exception("jsonPath cannot be null");

            if (!jsonPath.ToLower().Contains(".json"))
                throw new Exception("jsonPath need specify the extension");

            try
            {
                var stackFrame = new StackFrame(1);

                FireBase.AuthKey = authKey;
                FireBase.BaseUrl = baseUrl;
                FireBase.JsonPath = jsonPath;

                var details = new Details()
                {
                    RadarType = RadarType.StartRadar.ToString(),
                    Description = description,
                    VariableType = string.Empty,
                    Value = string.Empty,
                    FileName = fileName,
                    Method = stackFrame.GetMethod().Name,
                    Environment = Environment.MachineName
                };

                FireBase.InsertData(details);

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Register information about the variable on the current map cycle
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="description"></param>
        /// <param name="fileName"></param>
        public static void Track(this object variable, string description = "", [CallerFilePath] string fileName = null)
        {
            try
            {
                var stackFrame = new StackFrame(1);
                var variableValue = variable.ToString();

                if (variable.GetType().IsGenericType)
                    variableValue = JsonConvert.SerializeObject(variable);

                var details = new Details()
                {
                    RadarType = RadarType.Track.ToString(),
                    Description = description,
                    VariableType = variable.GetType().Name,
                    Value = variableValue,
                    FileName = fileName,
                    Method = stackFrame.GetMethod().Name,
                    Environment = Environment.MachineName
                };

                FireBase.InsertData(details);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Register information on the current mapping cycle
        /// </summary>
        /// <param name="description"></param>
        /// <param name="fileName"></param>
        public static void Information(string description, [CallerFilePath] string fileName = null)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("description cannot be null or empty");

            try
            {
                var stackFrame = new StackFrame(1);

                var details = new Details()
                {
                    RadarType = RadarType.Information.ToString(),
                    Description = description,
                    VariableType = string.Empty,
                    Value = string.Empty,
                    FileName = fileName,
                    Method = stackFrame.GetMethod().Name,
                    Environment = Environment.MachineName
                };

                FireBase.InsertData(details);

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Map Exception information
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="description"></param>
        /// <param name="fileName"></param>
        public static void Error(this Exception exception, string description = "", [CallerFilePath] string fileName = null)
        {
            try
            {
                var stackFrame = new StackFrame(1);

                var details = new Details()
                {
                    RadarType = RadarType.Error.ToString(),
                    Description = description,
                    VariableType = exception.GetType().Name,
                    Value = exception.Message,
                    FileName = fileName,
                    Method = stackFrame.GetMethod().Name,
                    Environment = Environment.MachineName
                };

                FireBase.InsertData(details);
            }
            catch (Exception)
            {

            }
        }
    }
}
