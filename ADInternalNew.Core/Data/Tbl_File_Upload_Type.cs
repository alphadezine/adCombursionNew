using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_File_Upload_Type
	{
		AdmisInternalDataContext context;
		public Tbl_File_Upload_Type(AdmisInternalDataContext pcontext = null)
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
		public int add(string File_Upload_Type_Value)
		{
			try{
				File_Upload_Type objFile_Upload_Type=new File_Upload_Type();
				objFile_Upload_Type.File_Upload_Type_Value=File_Upload_Type_Value;
				context.File_Upload_Types.InsertOnSubmit(objFile_Upload_Type);
				context.SubmitChanges();
				return objFile_Upload_Type.File_Upload_Type_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int File_Upload_Type_Id,string File_Upload_Type_Value)
		{
			try{
				File_Upload_Type objFile_Upload_Type = (from i in context.File_Upload_Types where i.File_Upload_Type_Id == File_Upload_Type_Id select i).SingleOrDefault();
				if (objFile_Upload_Type != null)
				{
					objFile_Upload_Type.File_Upload_Type_Value=File_Upload_Type_Value;
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
		 public File_Upload_Type selectOne(int File_Upload_Type_Id)
		{
			try
			{
				return (from i in context.File_Upload_Types where i.File_Upload_Type_Id == File_Upload_Type_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<File_Upload_Type> selectAll()
		{
			try
			{
				return (from i in context.File_Upload_Types  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

