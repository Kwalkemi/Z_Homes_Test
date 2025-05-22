namespace Z_Homes_Test.Business
{
    public class HRAComponent : ISalaryComponent
    {
        public decimal GetAmount(int amt)
        {
            return (15 * amt)/100;
        }
    }
}
