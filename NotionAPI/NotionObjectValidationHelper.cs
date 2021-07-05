using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NotionAPI.Models;

namespace NotionAPI
{
    public static class NotionObjectValidationHelper
    {
        public static void WriteErrorsAndWarnings(this NotionObject obj, string name)
        {
            var errors = new List<string>();
            var warnings = new List<string>();
            GetAllErrors(obj, name, errors, warnings);
            if (errors.Count != 0)
            {
                Console.WriteLine("Errors:");
            }
            foreach(var error in errors)
            {
                Console.WriteLine($"\t{error}");
            }
            if (warnings.Count != 0)
            {
                Console.WriteLine("Warnings:");
            }
            foreach (var warning in warnings)
            {
                Console.WriteLine($"\t{warning}");
            }
        }

        public static bool HasNoErrors(this NotionObject obj, string name)
        {
            var errors = new List<string>();
            var warnings = new List<string>();
            GetAllErrors(obj, name, errors, warnings);
            return errors.Count == 0;
        }

        public static bool HasNoWarnings(this NotionObject obj, string name)
        {
            var errors = new List<string>();
            var warnings = new List<string>();
            GetAllErrors(obj, name, errors, warnings);
            return warnings.Count == 0;
        }

        private static bool HasNoError(this NotionObject obj)
        {
            return !(obj is NotionClientError);
        }

        private static void GetAllErrors(this NotionObject obj, string name, List<string> errors, List<string> warnings)
        {
            if (obj.HasNoError())
            {
                foreach(var item in obj._additionalData)
                {
                    warnings.Add(Path.Combine(name, item.Key));
                }
                foreach (var property in obj.GetType().GetProperties().Where(x => x.GetType() == typeof(NotionObject)))
                {
                    GetAllErrors(property.GetValue(obj) as NotionObject, Path.Combine(name, property.Name), errors, warnings);
                }
            }
            else
            {
                errors.Add(name);
            }          
        }
    }
}
