using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreTemplate.Utility
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        //private readonly TraceSource _source;
        public GlobalExceptionFilter()
        {
            //_source = new TraceSource("CEREBRIWeb");
        }

        public void OnException(ExceptionContext context)
        {
            //This stops bubbling of exception
            context.ExceptionHandled = true;

            //writes error to trace
            //_source.WriteError(context.Exception);

            //redirects to Error Page
            context.Result = new RedirectToActionResult("Error", "Home", null);
        }
    }
}
