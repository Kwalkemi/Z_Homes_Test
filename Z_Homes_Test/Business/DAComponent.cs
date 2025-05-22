namespace Z_Homes_Test.Business
{
    public class DAComponent : ISalaryComponent
    {
        public decimal GetAmount(int amt)
        {
            return (10 * amt) / 100;
        }
    }
}
