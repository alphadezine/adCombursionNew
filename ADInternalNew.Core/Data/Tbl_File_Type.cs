using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_File_Type
	{
		AdmisInternalDataContext context;
		public Tbl_File_Type(AdmisInternalDataContext pcontext = null)
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
		public int add(string File_Type_Name)
		{
			try{
				File_Type objFile_Type=new File_Type();
				objFile_Type.File_Type_Name=File_Type_Name;
				context.File_Types.InsertOnSubmit(objFile_Type);
				context.SubmitChanges();
				return objFile_Type.File_Type_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int File_Type_Id,string File_Type_Name)
		{
			try{
				File_Type objFile_Type = (from i in context.File_Types where i.File_Type_Id == File_Type_Id select i).SingleOrDefault();
				if (objFile_Type != null)
				{
					objFile_Type.File_Type_Name=File_Type_Name;
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
		 public File_Type selectOne(int File_Type_Id)
		{
			try
			{
				return (from i in context.File_Types where i.File_Type_Id == File_Type_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<File_Type> selectAll()
		{
			try
			{
				return (from i in context.File_Types  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

