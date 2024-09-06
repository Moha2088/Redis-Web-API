namespace Re_Test.Extensions
{
    public static class EnvironmentExtensions
    {
        public static bool IsTestEnv(this IWebHostEnvironment env)
        {
            return env.EnvironmentName.Equals("TestEnv");
        }
    }
}
