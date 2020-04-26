using IncludeStudio.Util.Domain.Data;
using IncludeStudio.Util.Domain.Entities;
using IncludeStudio.Util.Domain.Enums;
using System;
using System.Diagnostics;

namespace IncludeStudio.Util.Radar
{
    public static class Logger
    {
        public static FireBase fireBase = new FireBase();

        public static void StartRadar(string description)
        {
            try
            {
                if (!string.IsNullOrEmpty(description))
                {
                    var stackFrame = new StackFrame(1);

                    var details = new Details()
                    {
                        IdDetails = new Guid(),
                        RadarType = RadarType.StartRadar,
                        Description = description,
                        VariableType = string.Empty,
                        Value = string.Empty,
                        FileName = stackFrame.GetFileName(),
                        Method = stackFrame.GetMethod().Name,
                        Environment = Environment.MachineName
                    };

                    fireBase.InsertData(details);
                }
            }
            catch (Exception)
            {

            }
        }

        public static void Track(this object variable , string description = "")
        {
            try
            {
                var stackFrame = new StackFrame(1);

                var details = new Details()
                {
                    IdDetails = new Guid(),
                    RadarType = RadarType.Track,
                    Description = description,
                    VariableType = variable.GetType().Name,
                    Value = variable.ToString(),
                    FileName = stackFrame.GetFileName(),
                    Method = stackFrame.GetMethod().Name,
                    Environment = Environment.MachineName
                };

                fireBase.InsertData(details);
            }
            catch (Exception)
            {

            }
        }

        public static void Information(string description)
        {
            try
            {
                var stackFrame = new StackFrame(1);

                if (!string.IsNullOrEmpty(description))
                {
                    var details = new Details()
                    {
                        IdDetails = new Guid(),
                        RadarType = RadarType.Information,
                        Description = description,
                        VariableType = string.Empty,
                        Value = string.Empty,
                        FileName = stackFrame.GetFileName(),
                        Method = stackFrame.GetMethod().Name,
                        Environment = Environment.MachineName
                    };

                    fireBase.InsertData(details);
                }
            }
            catch (Exception)
            {

            }
        }

        public static void Error(this Exception exception, string description = "")
        {
            try
            {
                var stackFrame = new StackFrame(1);

                var details = new Details()
                {
                    IdDetails = new Guid(),
                    RadarType = RadarType.Error,
                    Description = description,
                    VariableType = exception.GetType().Name,
                    Value = exception.Message,
                    FileName = stackFrame.GetFileName(),
                    Method = stackFrame.GetMethod().Name,
                    Environment = Environment.MachineName
                };

                fireBase.InsertData(details);

            }
            catch (Exception)
            {

            }
        }
    }
}
