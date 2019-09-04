using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZContacts.Entities;

namespace XYZContacts.DataAccessLayer.Context
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            List<Department> Departmentlar = new List<Department>();
            List<Employee> Employeelar = new List<Employee>();
            List<Title> Titlelar = new List<Title>();

            Department dp1 = new Department() { ID = Guid.NewGuid(), DepartmentName = "Satış" }; Departmentlar.Add(dp1);
            Department dp2 = new Department() { ID = Guid.NewGuid(), DepartmentName = "Muhasebe" }; Departmentlar.Add(dp2);
            Department dp3 = new Department() { ID = Guid.NewGuid(), DepartmentName = "İnsan Kaynakları" }; Departmentlar.Add(dp3);
            Department dp4 = new Department() { ID = Guid.NewGuid(), DepartmentName = "Pazarlama" }; Departmentlar.Add(dp4);
            Department dp5 = new Department() { ID = Guid.NewGuid(), DepartmentName = "AR-GE" }; Departmentlar.Add(dp5);
            Department dp6 = new Department() { ID = Guid.NewGuid(), DepartmentName = "Finans" }; Departmentlar.Add(dp6);
            Department dp7 = new Department() { ID = Guid.NewGuid(), DepartmentName = "Operasyon" }; Departmentlar.Add(dp7);

            context.Departments.AddRange(Departmentlar);

            context.SaveChanges();

            Title uv1 = new Title() { ID = Guid.NewGuid(), TitleName = "Personel" }; Titlelar.Add(uv1);
            Title uv2 = new Title() { ID = Guid.NewGuid(), TitleName = "Yönetici" }; Titlelar.Add(uv2);
            Title uv3 = new Title() { ID = Guid.NewGuid(), TitleName = "Müdür"  }; Titlelar.Add(uv3);
            Title uv4 = new Title() { ID = Guid.NewGuid(), TitleName = "Genel Müdür" }; Titlelar.Add(uv4);
            Title uv5 = new Title() { ID = Guid.NewGuid(), TitleName = "CEO" }; Titlelar.Add(uv5);

            context.Titles.AddRange(Titlelar);
            context.SaveChanges();

            Random rnd = new Random();

            for (int i = 0; i < 400; i++)
            {
                Employee c1 = new Employee();

                c1.Id = Guid.NewGuid();
                c1.Name = FakeData.NameData.GetFirstName();
                c1.Surname = FakeData.NameData.GetSurname();
                c1.PhoneNumbersI = FakeData.PhoneNumberData.GetPhoneNumber();
                c1.PhoneNumbersII = FakeData.PhoneNumberData.GetPhoneNumber();
                c1.Email = FakeData.NetworkData.GetEmail();
                c1.DepartmentId = Departmentlar[rnd.Next(0, 6)].ID;
                c1.TitleId = Titlelar[rnd.Next(0, 4)].ID;
                c1.About = FakeData.TextData.GetSentences(3);
              




                context.Employees.Add(c1);
            }

            context.SaveChanges();

            AppRole t1 = new AppRole() {ID=Guid.NewGuid(),RoleLimit=999,Description="unlimited authorized",RoleName="Admin" };
            AppRole t2 = new AppRole() {ID=Guid.NewGuid(),RoleLimit=1,Description= "not authorized", RoleName="Manager" };
            AppRole t3 = new AppRole() {ID=Guid.NewGuid(),RoleLimit=0,Description=" authorized",RoleName="User" };

            context.AppRoles.Add(t1);
            context.AppRoles.Add(t2);
            context.AppRoles.Add(t3);

            context.SaveChanges();

            Employee e = new Employee();

            e.Id = Guid.NewGuid();
            e.Name = "Mahsun";
            e.Surname = "Emrem";
            e.PhoneNumbersI= FakeData.PhoneNumberData.GetPhoneNumber();
            e.PhoneNumbersII= FakeData.PhoneNumberData.GetPhoneNumber();
            e.DepartmentId= Departmentlar[rnd.Next(0, 6)].ID;
            e.About= FakeData.TextData.GetSentences(3);
            e.Email = FakeData.NetworkData.GetEmail();
            e.TitleId = Titlelar[rnd.Next(0, 4)].ID;
       


            context.Employees.Add(e);

            AppIdentity identity = new AppIdentity();

            identity.Id = e.Id;
            identity.Username = e.Name + e.Surname;
            identity.Password= e.Name + e.Surname;
            identity.IdentityState = IdentityState.Active;
            identity.AppRoleId = t1.ID;

            context.AppIdentities.Add(identity);


            base.Seed(context);
        }
    }
}
