using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Status
	{
		AdmisInternalDataContext context;
		public Tbl_User_Status(AdmisInternalDataContext pcontext = null)
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
		public int add(string User_Status_Name)
		{
			try{
				User_Status objUser_Status=new User_Status();
				objUser_Status.User_Status_Name=User_Status_Name;
				context.User_Status.InsertOnSubmit(objUser_Status);
				context.SubmitChanges();
				return objUser_Status.User_Status_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_Status_Id,string User_Status_Name)
		{
			try{
				User_Status objUser_Status = (from i in context.User_Status where i.User_Status_Id == User_Status_Id select i).SingleOrDefault();
				if (objUser_Status != null)
				{
					objUser_Status.User_Status_Name=User_Status_Name;
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
		 public User_Status selectOne(int User_Status_Id)
		{
			try
			{
				return (from i in context.User_Status where i.User_Status_Id == User_Status_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Status> selectAll()
		{
			try
			{
				return (from i in context.User_Status  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

