
//----------------------------------------------------------------------------------------------------------
//~ Victor Rios~ ~ Black H 
//~ Estudiante Ing. Forestal UNALMED
//~ Estudiante Desarrollo de software

//GitHub: https://github.com/BlackH033
//Replit: https://replit.com/@vdrf

//Contacto
//   - vdriosf@unal.edu.co
//   - 3225920497

//----------------------------------------------------------------------------------------------------------

//Producto Lenguajes de Programación

//----------------------------------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;

namespace Entrega1
{
    class Program
    {
        static void Main(string[] args)
        {
            String cuenta="",clave="";
            bool ingreso = false;
            

            for (int i = 1; i <= 3; i++)
            {
                Console.Clear();
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("\t\t Bienvenid@\n");
                Console.Write("Ingrese número de cuenta: ");
                cuenta = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                clave = Console.ReadLine();
                Console.WriteLine("_____________________________________________");
                if (base_datos.validar(cuenta, clave))
                {
                    Console.Clear();
                    ingreso = true;
                    break;
                }
                else
                {
                    if (i == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("_____________________________________________");
                        Console.WriteLine("\n\t !!Cuenta bloqueada!!");
                        Console.WriteLine("este fue el último intento de los 3.\ncomunicate con atención al cliente.");
                        Console.WriteLine("_____________________________________________");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("_____________________________________________");
                        Console.WriteLine("\n\t !!Datos incorrectos!!");
                        Console.WriteLine("\nllevas " + i + " intentos.\nal 3 intento se bloqueara la cuenta");
                        Console.WriteLine("_____________________________________________");
                        Console.WriteLine("presiona enter para volver a intentarlo");
                        Console.ReadKey();
                    }
                    
                }
            }

            if (ingreso)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Cuenta: " + cuenta);
                    menu();
                    Console.Write("Ingrese una Opción: ");
                    int opcion = int.Parse(Console.ReadLine());
                    Console.WriteLine("_____________________________________________");
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine("La consulta del saldo tiene un cobro del 0.1%.");
                            Console.WriteLine("desea continuar?\n1. Si\n2. No");
                            Console.Write("ingrese una opción: ");
                            int opcion2 = int.Parse(Console.ReadLine());

                            if (opcion2 == 1)
                            {
                                float info = base_datos.saldo(cuenta);
                                Console.Clear();
                                Console.WriteLine("Cuenta: " + cuenta);
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("\nSaldo total:\t$" + info);
                                Console.WriteLine("_____________________________________________");
                            }
                            
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Cuenta: " + cuenta);
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine("\t\tTransferencia\n");
                            Console.Write("Ingrese cuenta destino: ");
                            string destin = Console.ReadLine();
                            Console.Write("valor a transferir: ");
                            string val = Console.ReadLine();
                            Console.WriteLine("presiona enter para confirmar");
                            Console.ReadKey();
                            if (base_datos.transferencia(cuenta,destin,val))
                            {
                                Console.Clear();
                                Console.WriteLine("Cuenta: " + cuenta);
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("\t  Tranferencia exitosa\n");
                                Console.WriteLine("Cuenta destino: " + destin);
                                Console.WriteLine("Valor: " + val);
                                var datos = base_datos.consulta(cuenta, false);
                                Console.WriteLine("\nSaldo en cuenta:\t$" + datos[2]);
                                Console.WriteLine("_____________________________________________");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("\n\t !!SALDO INSUFICIENTE!!");
                                Console.WriteLine("_____________________________________________");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Cuenta: " + cuenta);
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine("\t\tConsignación\n");
                            Console.Write("valor a transferir: ");
                            string cons = Console.ReadLine();
                            Console.WriteLine("presiona enter para confirmar");
                            Console.ReadKey();
                            
                            if (base_datos.consigna(cuenta, cons))
                            {
                                Console.Clear();
                                Console.WriteLine("Cuenta: " + cuenta);
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("\t  Consignación exitosa\n");
                                Console.WriteLine("Valor: " + cons);
                                var datos = base_datos.consulta(cuenta, false);
                                Console.WriteLine("\nSaldo en cuenta:\t$" + datos[2]);
                                Console.WriteLine("_____________________________________________");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("\n\t !!Valor erroneo!!");
                                Console.WriteLine("_____________________________________________");
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Cuenta: " + cuenta);
                            Console.WriteLine("_____________________________________________");
                            Console.WriteLine("\t\t    Cambio de clave\n");
                            Console.Write("Clave nueva: ");
                            string clave1 = Console.ReadLine();
                            Console.Write("Confirmación clave: ");
                            string clave2 = Console.ReadLine();
                            Console.WriteLine("presiona enter para confirmar");
                            Console.ReadKey();
                            if (clave1.Equals(clave2))
                            {
                                if (clave1.Length==4)
                                {
                                    base_datos.cambio(clave1);
                                    Console.Clear();
                                    Console.WriteLine("Cuenta: " + cuenta);
                                    Console.WriteLine("_____________________________________________");
                                    Console.WriteLine("\t  Cambio exitoso\n");
                                    var datos = base_datos.consulta(cuenta, false);
                                    Console.WriteLine("\nClave nueva: " + datos[1]);
                                    Console.WriteLine("_____________________________________________");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("_____________________________________________");
                                    Console.WriteLine("\n  !!ERROR debe tener 4 digitos!!");
                                    Console.WriteLine("_____________________________________________");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("_____________________________________________");
                                Console.WriteLine("\n  !!ERROR confirrmación diferente!!");
                                Console.WriteLine("_____________________________________________");
                            }
                            break;

                    }
                    if (opcion == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("_____________________________________________");
                        Console.WriteLine("\n   GRACIAS POR USAR NUESTROS SERVICIOS");
                        Console.WriteLine("_____________________________________________");
                        break;
                    }
                    Console.WriteLine("presiona cualquier tecla para volver al menú");
                    Console.ReadKey();
                }
               
            }

            Console.WriteLine("presiona cualquier tecla para terminar");
            Console.ReadKey();
        }


        //funciones
        public static void menu()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("\t\t Menú opciones\n");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Transferir");
            Console.WriteLine("3. Consignar");
            Console.WriteLine("4. Cambiar clave");
            Console.WriteLine("5. Salir");
        }

        //clase con funciones
        public static class base_datos
        {
            //variables globales ("base de datos de las cuentas")
            static List<string> C_numero = new List<string> { "11", "22", "33", "44" };
            static List<string> C_clave = new List<string> { "1234", "5678", "2211", "4433" };
            static List<string> C_saldo = new List<string> { "22000000", "8000000", "3500000", "2850000" };
            static int usuario = 0;

            //función para validar la existencia de la cuenta y el ingreso
            public static bool validar(string cuenta, string clave)
            {
                var info = consulta(cuenta, false);
                if (info.Count == 0)
                {
                    return false;
                }
                if (cuenta.Equals(info[0]) && clave.Equals(info[1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //función para traer la información de la cuenta
            public static IList consulta(String cuenta, bool consul_saldo)
            {
                var consulta = new List<string>();
                for (int i = 0; i < base_datos.C_numero.Count; i++)
                {
                    if (cuenta.Equals(C_numero[i]))
                    {
                        consulta.Add(C_numero[i]);
                        consulta.Add(C_clave[i]);
                        consulta.Add(C_saldo[i]);
                        usuario = i;
                        if (consul_saldo)
                        {
                            float x = (float)(float.Parse(consulta[2]) * 0.999);
                            consulta[2] = x.ToString();
                            C_saldo[i] = x.ToString();
                        }
                        break;
                    }

                }

                return consulta;
            }

            //función para consignar el saldo
            public static float saldo(String cuenta)
            {
                var info = consulta(cuenta, true);
                float saldo = float.Parse((string)info[2]);
                return saldo;
            }

            //función para tranferencia
            public static bool transferencia(String cuenta,String destino, String valor)
            {

                var datos = consulta(cuenta, false);
                if (float.Parse(valor)<=float.Parse((string)datos[2]))
                {
                    C_saldo[usuario] = (float.Parse(C_saldo[usuario]) - float.Parse(valor)).ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //función para consignar
            public static bool consigna(String cuenta,String valor)
            {
                if (float.Parse(valor)>=10000 && float.Parse(valor) <= 10000000)
                {
                    C_saldo[usuario] = (float.Parse(C_saldo[usuario]) + float.Parse(valor)).ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //función cambiar de contraseña
            public static void cambio(String clave)
            {
                C_clave[usuario] = clave;
            }
        }

        
    }
}
