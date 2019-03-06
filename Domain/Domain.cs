using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Domain : Framework.SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "query":
                    return Query((string)args[0]);
                case "register":
                    return Register((string)args[0], (byte[])args[1]);
                case "transfer":
                    return Transfer((string)args[0], (byte[])args[1]);
                case "delete":
                    return Delete((string)args[0]);
                default:
                    return false;
            }
        }

        private static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        private static bool Register(string domain, byte[] owner)
        {
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        private static bool Transfer(string domain, byte[] to)
        {

            for (int i = 0; i < 10; i++)
            {
                Console.Out.WriteLine("Teste" +i);
                Console.Out.WriteLine("Teste" +i);
            }
            
            if (!Runtime.CheckWitness(to)) return false;
            byte[] from = Storage.Get(Storage.CurrentContext, domain);
            if (from == null) return false;
            if (!Runtime.CheckWitness(from)) return false;
            Storage.Put(Storage.CurrentContext, domain, to);
            return true;
        }

        private static bool Delete(string domain)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Out.WriteLine("Teste" +i);
                Console.Out.WriteLine("Teste" +i);
            }
            
            printText();
            byte[] owner = Storage.Get(Storage.CurrentContext, domain);
            if (owner == null) return false;
            if (!Runtime.CheckWitness(owner)) return false;
            Storage.Delete(Storage.CurrentContext, domain);
            return true;
        }

        public static void  printText()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Out.WriteLine("Teste" +i);
                Console.Out.WriteLine("Teste" +i);
            }
        }
        
        public void  listTest()
        {
            var l = new List<String>();

            if (new Random().Next(0, 2) == 0)
            {
                l.Add("Test");
            }

            Console.Out.WriteLine(l != null ? l.First() : "empty");
            Console.Out.WriteLine(l?.First() ?? "empty");

            foreach (var VARIABLE in l)
            {
                Console.Out.WriteLine(VARIABLE);
            }
            
            foreach (String VARIABLE in l)
            {
                Console.Out.WriteLine(VARIABLE);
            }

            int i = 5;
            i = new Random().Next(0, 10);
            if (i == 6)
            {
            Console.Out.WriteLine("wrong alignment");  
            }
            
            if (new Random().Next(0, 3) == 0)
            {
                this.listTest();
                listTest();
            }

            if (new Random().Next(0, 2) == 0)
            {
                if (new Random().Next(0, 2) == 0)
                {
                    
                }
            }
        }
    }
}
