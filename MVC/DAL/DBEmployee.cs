namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
public class DBEmployee
{

    public static string connstring = @"server=localhost;
                                port=3306;
                                user=root;
                                password=root;
                                database=test";

public static bool Insert(int eid,string ename,string city,string sallary)
{

 bool  status=false;
    string query="insert into emplyee(eid,ename,city,sallary)"+"Values('"+eid+"','"+ename+"','"+city+"','"+sallary+"')";
  MySqlConnection con=new MySqlConnection();
    con.ConnectionString=connstring;
try{
con.Open();
MySqlCommand cmd=new MySqlCommand(query,con);
cmd.ExecuteNonQuery();
status=true;

}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
finally{
    con.Close();
}
return status;
}


public static List<Employee> GetallEmployee()
{
    List<Employee>list=new List<Employee>();

MySqlConnection con=new MySqlConnection();
con.ConnectionString=connstring; //gets the mysql connection string which client is to be client


try{
con.Open();

MySqlCommand cmd=new MySqlCommand();
cmd.Connection=con;

string query="select * from employee";
cmd.CommandText=query;

MySqlDataReader reader=cmd.ExecuteReader();
    
    while(reader.Read())
    {
int eid= int.Parse(reader["eid"].ToString());
string ename=reader["ename"].ToString();
string city=reader["city"].ToString();
string sallary=reader["sallary"].ToString();
student dobj=new student{
    eid=eid,
    ename=ename,
    city=city,
    sallary=sallary
    } ;
    list.Add(dobj);
    }
   }
catch(Exception e){Console.WriteLine(e.Message);}
finally{
con.Close();
}
    
    return list;
}
}