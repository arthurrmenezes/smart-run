public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Authentication with JWT Bearer Configuration

        #endregion

        #region Infrastructure Dependencies Configuration

        #endregion

        #region Application Dependencies Configuration

        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}