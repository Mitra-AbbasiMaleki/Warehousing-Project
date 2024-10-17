#nullable disable
using BaseBackend.Entities.Interfaces;
using BaseBackend.Enums;
using System;
namespace BaseBackend.Entities
{
    public class SysetmUser:Person, IBaseEntity, ICreateableEntity, IDeleteableEntity, IUpdatableEntity
    {
        public decimal Salary { get; set; }       // حقوق
        public string UserName { get; private set; }  //نام کاربری
        //private string Password { get; private set; }  // رمزعبور
        private string Password
        {
            set
            {
                if (value.Length >= 5)
                {
                    Password = value; // ذخیره رمز عبور
                }
                else
                {
                    throw new Exception("رمز عبور باید حداقل 6 کاراکتر باشد.");
                }
            }
        }
        //کلاس سازنده کارمند
        public SysetmUser(string userName,string password,UserRole role, string firstName, string lastName, string nationalCode, string phoneNumber, string address)
            : base(role, firstName, lastName, nationalCode, phoneNumber, address)//فراخوانی سازنده کلاس پایه
        {
            UserName = userName;
            Password = password;
        }
        public SysetmUser(UserRole role, string firstName, string lastName, string nationalCode, string phoneNumber, string address)
            : base(role, firstName, lastName, nationalCode, phoneNumber, address)//فراخوانی سازنده کلاس پایه
        {
        }
        public SysetmUser(UserRole role, string firstName, string lastName, string nationalCode)
            : base(role, firstName, lastName, nationalCode)//فراخوانی سازنده کلاس پایه
        {
        }

        // ویرایش اطلاعات تماس کاربر
        public new void UpdateContactInfo(string newPhoneNumber, string newEmail, string newAddress)
        {
            PhoneNumber = newPhoneNumber;
            Address = newAddress;
        }

        // به‌روزرسانی حقوق
        public void UpdateSalary(decimal newSalary)
        {
            Salary = newSalary;
        }
        // به‌روزرسانی موقعیت شغلی
        public void UpdateRole(UserRole newRole)
        {
            // newRoleبررسی معتبر بودن 
            if (Enum.IsDefined(typeof(UserRole), newRole))
                Role = newRole;
        }
        
    }

}
