namespace Proyecto2;

using System.Text;

//Clase BankAccount. En esta clase estan las metodos principales del programa: AccountDebit, AccountCredit, AccountQuery
//Todos las funciones requeridas para el proyecto son funciones derivadas que utilizan como base estas 3 funciones.
public class BankAccount
{
    public string Owner { get; set; }   
    public string Type { get; set; }
    public string phoneNumber { get; set; }
    public string id {get; set; }
    public string address { get; set; }
    public string AccountNumber { get; set; }  
    public decimal balance { get; set; }

#region Constructor
    public BankAccount(string[] accountData)
    {

        Type = accountData[1];  
        Owner = accountData[0];
        phoneNumber = accountData[2];
        id = accountData[3];
        InternalProcesses internalProcesses = new InternalProcesses();
        AccountNumber = internalProcesses.AccountId(Type);
        address = accountData[4];
        balance = decimal.Parse(accountData[6]);

    }
#endregion

#region Transactions
    public decimal AccountCredit(decimal amount){
        if(amount <= 0){
            throw new ArgumentOutOfRangeException(nameof(amount), "La cifra para credito a la cuenta debe ser mayor que 0   ");
        }
        else{
            balance += amount;
        }
        return balance;
    }

    public decimal AccountDebit(decimal amount){
        if(amount <= 0){
            throw new ArgumentOutOfRangeException(nameof(amount), "La cifra para debito a la cuenta debe ser mayor que 0   ");
        }
        if(balance - amount < 0){
            throw new InvalidOperationException("Falta de fondos para realizar el debito");
        }
        else{
            balance -= amount;
        }
        return balance;

    }
    public void AccountQuery(){
        StringBuilder stringBuilder= new StringBuilder();

        stringBuilder.AppendLine("Nombre: " + Owner);
        stringBuilder.AppendLine("Tipo de cuenta: " + Type);
        stringBuilder.AppendLine("No. de telefono: " + phoneNumber);
        stringBuilder.AppendLine("No. de DPI: " + id);
        stringBuilder.AppendLine("Direccion: " + address);	
        stringBuilder.AppendLine("No. de cuenta: " + AccountNumber);
        stringBuilder.AppendLine("Saldo de cuenta: " + balance);
            Console.WriteLine(stringBuilder);
    }
#endregion
}