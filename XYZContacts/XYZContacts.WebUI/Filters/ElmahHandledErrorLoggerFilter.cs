﻿using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XYZContacts.WebUI.Filters
{
    public class ElmahHandledErrorLoggerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
            {
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
            }
        }
    }
}