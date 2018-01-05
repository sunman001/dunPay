namespace Infrastructure
{
    public class BaseDbConnectionFactory : AbstractDbConnectionFactory
    {
        protected override string ConnectionStringName
        {
            get { return "ConnectionString"; }
        }
    }
}
