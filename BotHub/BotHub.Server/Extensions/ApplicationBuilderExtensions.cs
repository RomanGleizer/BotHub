namespace BotHub.Server.Extensions;

/// <summary>
/// Предоставляет методы расширения для IApplicationBuilder для настройки промежуточного ПО приложения.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Настраивает промежуточное ПО приложения, включая обработку статических файлов, аутентификацию, авторизацию и маршрутизацию.
    /// </summary>
    /// <param name="app">Средство построения приложения (IApplicationBuilder), используемое для настройки промежуточного ПО.</param>
    /// <param name="env">Среда веб-хоста приложения (IWebHostEnvironment).</param>
    public static void ConfigureMiddleware(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("ReactPolicy");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("/index.html");
        });
    }
}