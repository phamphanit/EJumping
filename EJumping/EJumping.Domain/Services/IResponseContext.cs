using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Domain.Services
{
    public interface IResponseContext
    {
        bool IsError { get; }
        IReadOnlyDictionary<string, string> Errors { get; }
        IReadOnlyDictionary<string, string> Warnings { get; }
        IReadOnlyDictionary<string, string> Success { get; }
        IReadOnlyDictionary<string, string> Errors_Code { get; }
        void AddSuccess(string msg);
        void AddSuccess(string key, string msg);
        void AddError(string msg);
        void AddErrorCode(string code);
        void AddError(string key, string msg);
        void AddInfo(string msg);
        void AddInfo(string key, string msg);
        void AddWarning(string msg);
        void AddWarning(string key, string msg);
        void ClearError();
    }
}
