﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiJsonResult
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiJsonResult()
        {
            ErrorMessages = new List<string>();
            Messages = new List<string>();
        }

        /// <summary>
        /// Success or not: "Success" or "Error"
        /// </summary>
        public string Result { get { return ErrorMessages.Count == 0 ? ApiResult.Success.ToString() : ApiResult.Error.ToString(); } }

        /// <summary>
        /// List of error message strings
        /// </summary>
        public List<string> ErrorMessages
        {
            get;
            set;
        }

        /// <summary>
        /// List of messages
        /// </summary>
        public List<string> Messages { get; set; }
    }

    /// <summary>
    /// Api result
    /// </summary>
    public enum ApiResult
    {
        /// <summary>
        /// Successful
        /// </summary>
        Success = 1,

        /// <summary>
        /// Error
        /// </summary>
        Error = 2
    }
}
