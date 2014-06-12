using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Role
	{
		AdmisInternalDataContext context;
		public Tbl_Role(AdmisInternalDataContext pcontext = null)
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
		public int add(string Role_Name)
		{
			try{
				Role objRole=new Role();
				objRole.Role_Name=Role_Name;
				context.Roles.InsertOnSubmit(objRole);
				context.SubmitChanges();
				return objRole.Role_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Role_Id,string Role_Name)
		{
			try{
				Role objRole = (from i in context.Roles where i.Role_Id == Role_Id select i).SingleOrDefault();
				if (objRole != null)
				{
					objRole.Role_Name=Role_Name;
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
		 public Role selectOne(int Role_Id)
		{
			try
			{
				return (from i in context.Roles where i.Role_Id == Role_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Role> selectAll()
		{
			try
			{
				return (from i in context.Roles  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

