using EJumping.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJumping.Application.Services
{
    public class ResponseContext : IResponseContext
    {
        public ResponseContext()
        {
            errors = new Dictionary<string, string>();
            errors_code = new Dictionary<string, string>();
            warnings = new Dictionary<string, string>();
            infos = new Dictionary<string, string>();
            success = new Dictionary<string, string>();
        }
        public Dictionary<string, string> errors { get; }
        public Dictionary<string, string> errors_code { get; }
        public Dictionary<string, string> warnings { get; }
        public Dictionary<string, string> infos { get; }
        public Dictionary<string, string> success { get; }

        public IReadOnlyDictionary<string, string> Errors => errors;
        public IReadOnlyDictionary<string, string> Warnings => warnings;
        public IReadOnlyDictionary<string, string> Success => success;
        public IReadOnlyDictionary<string, string> Errors_Code => errors_code;


        public bool IsError
        {
            get
            {
                return errors.Any();
            }
        }

        public bool ISWarning
        {
            get
            {
                return warnings.Any();
            }
        }

        public bool IsInfo
        {
            get
            {
                return infos.Any();
            }
        }

        public void AddError(string msg)
        {
            errors.Add(Guid.NewGuid().ToString("n"), msg);
        }

        public void AddErrorCode(string code)
        {
            errors_code.Add(Guid.NewGuid().ToString("n"), code);
        }

        public void AddError(string key, string msg)
        {
            errors.Add(key, msg);
        }

        public void AddSuccess(string msg)
        {
            success.Add(Guid.NewGuid().ToString("n"), msg);
        }

        public void AddSuccess(string key, string msg)
        {
            success.Add(key, msg);
        }

        public void AddInfo(string msg)
        {
            infos.Add(Guid.NewGuid().ToString("n"), msg);
        }

        public void AddInfo(string key, string msg)
        {
            infos.Add(key, msg);
        }

        public void AddWarning(string msg)
        {
            warnings.Add(Guid.NewGuid().ToString("n"), msg);
        }

        public void AddWarning(string key, string msg)
        {
            warnings.Add(key, msg);
        }
        public void ClearError()
        {
            if (errors != null && this.errors.Any())
            {
                errors.Clear();
            }
        }
    }
}
