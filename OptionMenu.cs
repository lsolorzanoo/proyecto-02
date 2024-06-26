using Proyecto2;
namespace Menu;


//Clase OptionMenu. En esta clase tengo los dos menu's con los que cuenta el programa: El menu inicial que unicamente se ejecuta cuando el programa inicializa para la toma de datos.
//Y el menu Principal del programa el cual se ejecuta en un while desde el metodo Main en la clase Program
class OptionMenu{
    static string[] accountData = new string[8];
    InternalProcesses internalProcesses = new InternalProcesses();
    static string[] opciones = { "Ver informacion de la cuenta", "Compra de producto Financiero", "Venta de producto Financiero", "Abono a cuenta", "Simulacion paso del tiempo", "Mantenimiento de cuenta de terceros.", "Realizar transferencia a terceros.", "Pago de servicios","Imprimir informe de transacciones", "Salir" };
    static List<string> Logs = new List<string>();
    static string[,] thirdAccounts = new string[5,20];
    static int thirdAccountSeeds = 1;
    static string[] proveedores = {"Empresa de agua", "Empresa electrica","Telefonica"};

    public void FirstMenu(){
            accountData[0] = internalProcesses.AccountNameValidation();
            accountData[1] = internalProcesses.AccountTypeValidation();
            Console.WriteLine(accountData[1]);
            Console.ReadKey();
            accountData[2] = internalProcesses.AccountPhoneNumberValidation();
            accountData[3] = internalProcesses.AccountIdOwner();
            accountData[4] = internalProcesses.AccountAddresValidation();
            accountData[5] = internalProcesses.AccountId(accountData[1]);
            decimal initialBalance = 2500;
            accountData[6] = initialBalance.ToString();
        }
    
public  bool opcionesPrincipales(bool menu){
            Console.Clear();
            for (int i = 0; i < opciones.Length; i++){
                Console.WriteLine($"{i + 1}.{opciones[i]}");
            }
            Console.Write("Seleccione la accion que desea ejecutar indicando el numero de opcion: ");
            string? menuOpciones = Console.ReadLine();
            if(menuOpciones==""){
                Console.Clear();
                Console.WriteLine("Debe ingresar un valor");
                Console.ReadKey();
            }else{
            int menuOpcionesVal;
            menuOpcionesVal = int.Parse(menuOpciones ?? string.Empty);
            menu = switchCase2(menuOpcionesVal, menu);
            }   
            return menu; 
        }
        public static bool switchCase2( int menuOpciones,bool menu){
            OpcionesClass opcionesClass = new OpcionesClass();
            string operationType = "";
               switch (menuOpciones){
                    case 1:
                    opcionesClass.infoCuenta(accountData);
                    break;
                    
                    case 2 :
                    opcionesClass.compraProducto(accountData);
                    operationType = "Debito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);
                    break;

                    case 3:
                    opcionesClass.ventaProducto(accountData);
                    operationType = "Credito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);
                    break;

                    case 4:
                    opcionesClass.abonoCuenta(accountData);
                    operationType = "Credito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);
                    break;

                    case 5:
                    opcionesClass.pasoTiempo(accountData);
                    operationType = "Credito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);
                    break;

                    case 6:
                    opcionesClass.thirdPartyAccount(accountData, thirdAccounts, thirdAccountSeeds);
                    thirdAccountSeeds++;
                    operationType = "Debito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);
                    break; 

                    case 7:
                    opcionesClass.thirdAccountTransfers(accountData, thirdAccounts);
                    operationType = "Debito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);

                    break;
                    
                    case 8:
                    opcionesClass.servicesPay(accountData, proveedores);
                    operationType = "Debito";
                    opcionesClass.addLogs(Logs, opciones, menuOpciones, accountData, operationType);
                    break;

                    case 9:
                    opcionesClass.printLogs(Logs);
                    break;

                    case 10:
                    menu = false;
                    break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        break;

                }
                Console.ReadKey();
                return menu;

        }


}
