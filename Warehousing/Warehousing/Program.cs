#nullable disable
using System;
using System.Windows.Forms;
using BaseBackend.Entities;
using BaseBackend.Enums;

namespace Warehousing
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            Person Admin = new Person(role:UserRole.ADMIN,firstName: "mitra",lastName: "abbasi",nationalCode: "5310111107", phoneNumber: "09123456789",address: "tehran");
            Person User = new Person(role:UserRole.USER, firstName: "elham", lastName: "maleki", nationalCode: "7078184262", phoneNumber: "09987654321", address: "karaj");
            Customer customer1 = new Customer(role: UserRole.CUSTOMER, firstName: "ali", lastName: "alavi", nationalCode: "4320101014", phoneNumber: "09123456789", address: "esfahan");
            Customer customer2 = new Customer(role: UserRole.CUSTOMER, firstName: "reza", lastName: "rezaee", nationalCode: "0295255684", phoneNumber: "09187664321", address: "tabriz");
            Supplier supplier1 = new Supplier(role: UserRole.SUPPLIER, companyName:"kaleh", firstName: "ahmad", lastName: "ahmadi", nationalCode: "1971614866", phoneNumber: "09363636363", address: "hamadan");
            Supplier supplier2 = new Supplier(role: UserRole.SUPPLIER, companyName:"LG", firstName: "taha", lastName: "moradi", nationalCode: "0937955027", phoneNumber: "09854565352", address: "shiraz");
            Product Cloth = new Product(name: "Silk-Fabric", category:ProductCategory.Clothing, quantity: 20,unit:MeasurementUnit.Metr);
            Product Mobile = new Product(name: "Iphone15", quantity: 3, price: 250000000);
            Product Laptop = new Product(name: "Asus", category:ProductCategory.Electronics, quantity: 1);
            Product Butter = new Product(name: "Pak", category: ProductCategory.grocery, quantity: 10, unit: MeasurementUnit.pieces, price: 50000, expiryDate: new DateTime(1403, 09, 25), description: " Pak Butter");


        }
    }
}
