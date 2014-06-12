using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Login_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Login_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_To_Shift_Mapping_Id,int Current_Status)
		{
			try{
				Login_Master objLogin_Master=new Login_Master();
				objLogin_Master.User_To_Shift_Mapping_Id=User_To_Shift_Mapping_Id;
				objLogin_Master.Current_Status=Current_Status;
				context.Login_Masters.InsertOnSubmit(objLogin_Master);
				context.SubmitChanges();
				return objLogin_Master.Login_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Login_Id,int User_To_Shift_Mapping_Id,int Current_Status)
		{
			try{
				Login_Master objLogin_Master = (from i in context.Login_Masters where i.Login_Id == Login_Id select i).SingleOrDefault();
				if (objLogin_Master != null)
				{
					objLogin_Master.User_To_Shift_Mapping_Id=User_To_Shift_Mapping_Id;
					objLogin_Master.Current_Status=Current_Status;
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
		 public Login_Master selectOne(int Login_Id)
		{
			try
			{
				return (from i in context.Login_Masters where i.Login_Id == Login_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Login_Master> selectAll()
		{
			try
			{
				return (from i in context.Login_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

