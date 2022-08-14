namespace DinnerAidAPI.Data
{
    public static class DataSeeder
    {
        internal async static Task SeedData(IServiceProvider serviceprovider) 
        {
            using var scope = serviceprovider.CreateScope();
            {
                using var provider = scope.ServiceProvider.GetRequiredService<APIContext>();
                provider.Database.EnsureCreated();
            }
        }
    }
}
