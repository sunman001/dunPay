namespace Infrastructure
{
    public class LogDbConnectionFactory : AbstractDbConnectionFactory
    {
        protected override string ConnectionStringName
        {
            get { return "ConnectionStringLog"; }
        }
    }
}
