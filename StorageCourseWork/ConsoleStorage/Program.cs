using System;
using System.Collections.Generic;
using System.Drawing;
using BusinessStorage;
using EventArgs = BusinessStorage.EventArgs;

namespace ConsoleStorage
{
    class Program
    {
        static Storage storage = new Storage("Warehouse #1", "Kiev");
        static void Main(string[] args)
        {
            Good.OutputDel = DisplayMessage;
            StStack.OutputDel = DisplayWarning;
            Order.OutputDel = DisplayMainEvent;
            Storage.OutputDel = DisplayMainEvent;
            Storage.ShipmentCharge = 2;
            
            Good clothes = new Clothes("shirt", 15, 0.2, 0.001, Sizes.M, "cotton", "H&M");
            Good grocery = new Grocery("tomatos", 2,1, 0.002, 7, true);
            Good furniture = new Furniture("desk", 50,20,0.05, "oak", 0.7, 1.5, 1.1);
            Good[] list = {clothes, grocery, furniture};
            
            storage.AddStack(new StStack(clothes, 20));
            storage.AddStack(new StStack(grocery, 20));
            storage.AddStack(new StStack(furniture, 4));
            

            string Commands = "\n\n1.Add new stack \n2.Remove stack \n3.Refill existing stack \n4.Show stack info \n5.Make order " +
                              "\n6.Cancel order \n7.Show orders list \n8.Start completing orders \n9.Exit";

            string orderCommands = "\n1.Add position to order \n2.Remove position from order \n3.Approve order \n4.Back";

            string GoodTypes = "\n1.Clothes \n2.Grocery \n3.Furniture";
            
            char curCommand = '0';
            
            Console.WriteLine("Welcome to control panel of " + storage.Name + "!");

            while (curCommand != '9')
            {
                Console.WriteLine(Commands);
                curCommand = Console.ReadKey().KeyChar;
                switch (curCommand)
                {
                    case '1':
                        Console.WriteLine("\nChoose th type of stack:" + GoodTypes);
                        Good sample = null;
                        char type = Console.ReadKey().KeyChar;
                        GetMainInfo(out string name, out decimal price, out double volume, out double weight);
                        switch (type)
                        {
                            case '1':
                                GetClothesInfo(out Sizes size, out string material, out string brand);
                                sample = new Clothes(name, price, weight, volume, size, material, brand);
                                break;
                            case '2':
                                GetGroceryInfo(out int slife, out bool fragile);
                                sample = new Grocery(name, price, weight, volume, slife, fragile);
                                break;
                            case '3':
                                GetFurnitureInfo(out double width, out double length, out double height, out string fMaterial);
                                sample = new Furniture(name, price, weight, volume, fMaterial, width, length, height);
                                break;
                        }
                        Console.WriteLine("Enter number of items in stack:");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        StStack addStack = new StStack(sample, quantity);
                        storage.AddStack(addStack);
                        Console.WriteLine("\nNew stack has been added to storage.");
                        break;
                    case '2':
                        int delIndex = ChooseStack();
                        storage.RemoveStack(storage.StorageStacks[delIndex]);
                        Console.WriteLine("\nStack has been removed from the storage.");
                        break;
                    case '3':
                        int refIndex = ChooseStack();
                        Console.WriteLine("Enter quantity of refilling:");
                        int refQuant =  Convert.ToInt32(Console.ReadLine());
                        storage.StorageStacks[refIndex].Refill(refQuant);
                        break;
                    case '4':
                        int showIndex = ChooseStack();
                        Console.WriteLine("Stack id: " + storage.StorageStacks[showIndex].Id);
                        Console.WriteLine("Stack item: \n" + storage.StorageStacks[showIndex].Sample.ToString());
                        Console.WriteLine("Stack items' serial numbers:");
                        foreach (Good g in storage.StorageStacks[showIndex].Contents) Console.Write(g.SerialNumber + ", ");
                        break;
                    case '5':
                        Console.WriteLine("\nEnter your full name:");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Enter the address of delivery:");
                        string destination = Console.ReadLine();
                        Order order = new Order(fullName, destination); 
                        char orderCommand = '0';
                        while (orderCommand != '4')
                        {
                            Console.WriteLine(orderCommands);
                            orderCommand = Console.ReadKey().KeyChar;
                            switch (orderCommand)
                            {
                                case '1':
                                    Console.WriteLine("\nChoose item:");
                                    ShowStacks(storage);
                                    int posI = Convert.ToInt32(Console.ReadLine()) - 1;
                                    Console.WriteLine("Enter number of items to order:");
                                    int posQuant = Convert.ToInt32(Console.ReadLine());
                                    order.AddPosition(storage.StorageStacks[posI], posQuant);
                                    break;
                                case '2':
                                    if (order.Positions.Count > 0)
                                    {
                                        Console.WriteLine("\nChoose position to remove:");
                                        GetPositions(order);
                                        int posRemI = Convert.ToInt32(Console.ReadLine()) - 1;
                                        order.RemovePosition(order.Positions[posRemI]);
                                    }else Console.WriteLine("No position yet.");
                                    break;
                                case '3':
                                    storage.AddOrder(order);
                                    Console.WriteLine("\nOrder has been created. Order number is: " + order.OrderNumber);
                                    break;
                                default:
                                    Console.WriteLine("\nUnknown command.");
                                    break;
                            }
                        }
                        break;
                    case '6':
                        if (storage.Orders.Count > 0)
                        {
                            int canNumber = ChooseOrder();
                            storage.CancelOrder(canNumber);
                            Console.WriteLine("\nOreder number: " + canNumber + " has been canceled.");
                        }else Console.WriteLine("\nNo orders yet.");
                        break;
                    case '7':
                        if (storage.Orders.Count > 0) ShowOrders(storage);
                        else Console.WriteLine("\nNo orders yet.");
                        break;
                    case '8':
                        if (storage.Orders.Count > 0)
                        {
                            storage.CompleteOrders();
                        }else Console.WriteLine("No orders to complete.");
                        break;
                    default:
                        Console.WriteLine("\nUnknown command.");
                        break;
                }
            }
        }

        public static void GetPositions(Order o)
        {
            int index = 0;
            foreach (OrderPosition op in o.Positions) Console.WriteLine(++index + "." + op.FromStack.Sample.Name + ", " + op.Quantity);
        }
        public static void ShowStacks(Storage storage)
        {
            int index = 0;
            foreach (StStack st in storage.StorageStacks) Console.WriteLine(++index + "." + st.Sample.Name + ", id:" + st.Id);
        }

        public static void ShowOrders(Storage storage)
        {
            foreach (Order o in storage.Orders) Console.WriteLine("Number:" + o.OrderNumber + ", " + o.CustomerName);
        }
        public static int ChooseOrder()
        {
            Console.WriteLine("\nChoose order:");
            ShowOrders(storage);
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int ChooseStack()
        {
            Console.WriteLine("\nChoose stack:");
            ShowStacks(storage);
            return Convert.ToInt32(Console.ReadLine()) - 1;
        }
        public static void GetMainInfo(out string name, out decimal price, out double volume, out double weight)
        {
            Console.WriteLine("\nDefining items in stack:");
            Console.WriteLine("\nEnter a name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter shipment volume in cubic metres: ");
            volume = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter weight in kilos: ");
            weight = Convert.ToDouble(Console.ReadLine());
        }
        static string sizes = Sizes.XS.ToString() + "(44), " + Sizes.S.ToString() + "(46), " + Sizes.M.ToString() + "(48), " + Sizes.L.ToString()
                              + "(50), " + Sizes.XL.ToString() + "(52), " + Sizes.XXL.ToString() + "(54)";
        public static void GetClothesInfo(out Sizes size, out string material, out string brand)
        {
            Console.WriteLine("Choose size(eneter number): ");
            Console.WriteLine(sizes);
            size = (Sizes)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter material: ");
            material = Console.ReadLine();
            Console.WriteLine("Enter brand: ");
            brand = Console.ReadLine();
        }

        public static void GetGroceryInfo(out int slife, out bool fragile)
        {
            Console.WriteLine("Enter shelf life in days: ");
            slife = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 if the product is fragile else enter 0(defines package): ");
            fragile = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
        }

        public static void GetFurnitureInfo(out double width, out double length, out double height, out string material)
        {
            Console.WriteLine("Enter the dimensions of a furniture(width, length, heigth) in metres: ");
            width = Convert.ToDouble(Console.ReadLine());
            length = Convert.ToDouble(Console.ReadLine());
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter material: ");
            material = Console.ReadLine();
        }
        public static void DisplayMessage(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(args.Message);
        }
        
        public static void DisplayWarning(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        public static void DisplayMainEvent(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}


