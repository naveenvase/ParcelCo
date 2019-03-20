namespace ConsoleParcelApp
{
    /// <summary>The console application</summary>
    /// <remarks>This is essentally the entry point for the console app. It contains the core code
    /// specific to the  app, like getting inputs, and processing them to identify the best package
    /// solution </remarks>
    public interface IApp
    {
        /// <summary>Run the application, injecting constructor dependencies</summary>
        void Run();
    }
}
