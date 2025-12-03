namespace MapaEstoqueCD.Database.Common
{
    public static class ContextFactory
    {
        public static AppDbContext CreateDb()
        {
            return new AppDbContext();
        }
    }
}
