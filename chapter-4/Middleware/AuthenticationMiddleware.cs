
using chapter_4.BL;

namespace chapter_4.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UsersBL usersBL)
        {
            var test = context.Request.Headers;
            var userId = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (userId != null)
            {
                var userIdGuid = new Guid(userId);
                context.Items["UserId"] = await usersBL.GetUserByIdAsync(userIdGuid);
            }

            await _next(context);
        }
    }
}

