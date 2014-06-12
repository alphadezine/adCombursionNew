using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_File_Master
	{
		AdmisInternalDataContext context;
		public Tbl_File_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(string File_Name,string File_Url,int File_Type_Id,string File_Size,int File_Upload_Type_Id)
		{
			try{
				File_Master objFile_Master=new File_Master();
				objFile_Master.File_Name=File_Name;
				objFile_Master.File_Url=File_Url;
				objFile_Master.File_Type_Id=File_Type_Id;
				objFile_Master.File_Size=File_Size;
				objFile_Master.File_Upload_Type_Id=File_Upload_Type_Id;
				context.File_Masters.InsertOnSubmit(objFile_Master);
				context.SubmitChanges();
				return objFile_Master.File_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int File_Id,string File_Name,string File_Url,int File_Type_Id,string File_Size,int File_Upload_Type_Id)
		{
			try{
				File_Master objFile_Master = (from i in context.File_Masters where i.File_Id == File_Id select i).SingleOrDefault();
				if (objFile_Master != null)
				{
					objFile_Master.File_Name=File_Name;
					objFile_Master.File_Url=File_Url;
					objFile_Master.File_Type_Id=File_Type_Id;
					objFile_Master.File_Size=File_Size;
					objFile_Master.File_Upload_Type_Id=File_Upload_Type_Id;
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
		 public File_Master selectOne(int File_Id)
		{
			try
			{
				return (from i in context.File_Masters where i.File_Id == File_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<File_Master> selectAll()
		{
			try
			{
				return (from i in context.File_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

