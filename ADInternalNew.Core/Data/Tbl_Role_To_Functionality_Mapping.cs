using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Role_To_Functionality_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Role_To_Functionality_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Role_Id,int Functionality_Id)
		{
			try{
				Role_To_Functionality_Mapping objRole_To_Functionality_Mapping=new Role_To_Functionality_Mapping();
				objRole_To_Functionality_Mapping.Role_Id=Role_Id;
				objRole_To_Functionality_Mapping.Functionality_Id=Functionality_Id;
				context.Role_To_Functionality_Mappings.InsertOnSubmit(objRole_To_Functionality_Mapping);
				context.SubmitChanges();
				return objRole_To_Functionality_Mapping.Role_To_Functionality_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Role_To_Functionality_Mapping_Id,int Role_Id,int Functionality_Id)
		{
			try{
				Role_To_Functionality_Mapping objRole_To_Functionality_Mapping = (from i in context.Role_To_Functionality_Mappings where i.Role_To_Functionality_Mapping_Id == Role_To_Functionality_Mapping_Id select i).SingleOrDefault();
				if (objRole_To_Functionality_Mapping != null)
				{
					objRole_To_Functionality_Mapping.Role_Id=Role_Id;
					objRole_To_Functionality_Mapping.Functionality_Id=Functionality_Id;
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
		 public Role_To_Functionality_Mapping selectOne(int Role_To_Functionality_Mapping_Id)
		{
			try
			{
				return (from i in context.Role_To_Functionality_Mappings where i.Role_To_Functionality_Mapping_Id == Role_To_Functionality_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Role_To_Functionality_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Role_To_Functionality_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

