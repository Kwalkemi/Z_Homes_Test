namespace Z_Homes_Test.Business
{
    public class SalaryFactoryComponent
    {

        public ISalaryComponent GetSalaryComponent(string componentName)
        {
            switch (componentName)
            {
                case "HRA":
                    {
                        return new HRAComponent();
                    }
                case "TA":
                    {
                        return new TAComponent();
                    }
                case "DA":
                    {
                        return new DAComponent();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
