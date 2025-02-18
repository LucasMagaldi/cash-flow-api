﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Communication.Responses
{
    public class ResponseError
    {
        public List<string> ErrorMessages { get; set; }

        public ResponseError(string errorMessage) 
        {
            ErrorMessages =  [errorMessage];
        }

        public ResponseError(List<string> errorMessages) 
        {
            ErrorMessages = errorMessages;
        }
    }
}
