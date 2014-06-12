using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User
	{
		AdmisInternalDataContext context;
		public Tbl_User(AdmisInternalDataContext pcontext = null)
		{
			if (context == null)
			{
				context = new AdmisInternalDataContext();
			}
			else
			{
				context = pcontext;
			}
		}
		public int add(string First_Name,string Last_Name,string Username,string Email_Address,string Password,int User_Status_Id)
		{
			try{
				User objUser=new User();
				objUser.First_Name=First_Name;
				objUser.Last_Name=Last_Name;
				objUser.Username=Username;
				objUser.Email_Address=Email_Address;
				objUser.Password=Password;
				objUser.User_Status_Id=User_Status_Id;
				context.Users.InsertOnSubmit(objUser);
				context.SubmitChanges();
				return objUser.User_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Id,string First_Name,string Last_Name,string Username,string Email_Address,string Password,int User_Status_Id)
		{
			try{
				User objUser = (from i in context.Users where i.User_Id == User_Id select i).SingleOrDefault();
				if (objUser != null)
				{
					objUser.First_Name=First_Name;
					objUser.Last_Name=Last_Name;
					objUser.Username=Username;
					objUser.Email_Address=Email_Address;
					objUser.Password=Password;
					objUser.User_Status_Id=User_Status_Id;
					context.SubmitChanges();
					return true;
				}
				else
				{
					return false;
				}
 			}
			catch (Exception ex)
			{
				return false;
			}
		}
		 public User selectOne(int User_Id)
		{
			try
			{
				return (from i in context.Users where i.User_Id == User_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User> selectAll()
		{
			try
			{
				return (from i in context.Users  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

