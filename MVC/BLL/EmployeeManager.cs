namespace BLL;
using DAL;
using BOL;
public class EmployeeManager
{    
public static List<Employee> GetAllEmployeeFromDAL()
{
List<Employee>list=new List<Employee>();
list=DBEmployee.GetallEmployee();
    return list;
}

public bool insert(int eid,string ename,string city,string sallary)
{
    return DBEmployee.Insert(eid,ename,city,sallary);
} 

}
