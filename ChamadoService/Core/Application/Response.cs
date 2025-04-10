﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{

    public enum ErrorCodes
    {
        NOT_FOUND = 1,
        COULDNOT_STORE_DATA = 2,
    }
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorCodes ErrorCode { get; set; }
    }
}
