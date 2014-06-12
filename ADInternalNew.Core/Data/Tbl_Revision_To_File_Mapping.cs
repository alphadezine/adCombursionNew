using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Revision_To_File_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Revision_To_File_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Revision_Id,int File_Id)
		{
			try{
				Revision_To_File_Mapping objRevision_To_File_Mapping=new Revision_To_File_Mapping();
				objRevision_To_File_Mapping.Revision_Id=Revision_Id;
				objRevision_To_File_Mapping.File_Id=File_Id;
				context.Revision_To_File_Mappings.InsertOnSubmit(objRevision_To_File_Mapping);
				context.SubmitChanges();
				return objRevision_To_File_Mapping.Revision_To_File_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Revision_To_File_Mapping_Id,int Revision_Id,int File_Id)
		{
			try{
				Revision_To_File_Mapping objRevision_To_File_Mapping = (from i in context.Revision_To_File_Mappings where i.Revision_To_File_Mapping_Id == Revision_To_File_Mapping_Id select i).SingleOrDefault();
				if (objRevision_To_File_Mapping != null)
				{
					objRevision_To_File_Mapping.Revision_Id=Revision_Id;
					objRevision_To_File_Mapping.File_Id=File_Id;
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
		 public Revision_To_File_Mapping selectOne(int Revision_To_File_Mapping_Id)
		{
			try
			{
				return (from i in context.Revision_To_File_Mappings where i.Revision_To_File_Mapping_Id == Revision_To_File_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Revision_To_File_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Revision_To_File_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

