using bUtility;
using System;


namespace bookstore.controllers
{
    internal static class Extensions
    {
        internal static Response<R> SafeExecutor<R>(this ExceptionHandler exceptionHandler, Func<R> action) where R : class
        {
            var r = exceptionHandler.HandleException(action);
            SetGenericError(r?.Item2);
            return new Response<R> { Payload = r.Item1, Exception = r.Item2 };
        }
        private static void SetGenericError(ResponseMessage item2)
        {
            if (item2?.Category != ErrorCategory.Technical) return;
            item2.Description = "Oops...Something went wrong!";
            item2.Code = "101";
        }
    }

}
