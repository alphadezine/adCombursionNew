using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Revision
	{
		AdmisInternalDataContext context;
		public Tbl_Revision(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_To_User_Mapping_Id)
		{
			try{
				Revision objRevision=new Revision();
				objRevision.Order_To_User_Mapping_Id=Order_To_User_Mapping_Id;
				context.Revisions.InsertOnSubmit(objRevision);
				context.SubmitChanges();
				return objRevision.Revision_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Revision_Id,int Order_To_User_Mapping_Id)
		{
			try{
				Revision objRevision = (from i in context.Revisions where i.Revision_Id == Revision_Id select i).SingleOrDefault();
				if (objRevision != null)
				{
					objRevision.Order_To_User_Mapping_Id=Order_To_User_Mapping_Id;
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
		 public Revision selectOne(int Revision_Id)
		{
			try
			{
				return (from i in context.Revisions where i.Revision_Id == Revision_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Revision> selectAll()
		{
			try
			{
				return (from i in context.Revisions  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

