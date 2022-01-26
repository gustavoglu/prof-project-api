using Newtonsoft.Json;

namespace ProfProject.Middlewares
{
    public class ErroRespontaPadraoMidleware
    {
        public RequestDelegate _next;

        public ErroRespontaPadraoMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                var obj = new { success = false, data = new string[] { e.Message } };
                var json = JsonConvert.SerializeObject(obj);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
