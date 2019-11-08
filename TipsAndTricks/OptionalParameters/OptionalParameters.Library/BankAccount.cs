namespace OptionalParameters.Library
{
    public class BankAccount
    {
        //// Try changing the default value of the money parameter without pre-comping the client
        //// Try adding new optional parameter without pre-comping the client
        public BankAccount(string accountHolder = default, decimal money = 1000) // string country = "USA"
        {
            this.AccountHolder = accountHolder;
            this.Money = money;
            //// this.Country = country;
        }

        public string AccountHolder { get; set; }

        public decimal Money { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"Bank account of {this.AccountHolder} with {this.Money} in cash.";
        }
    }
}