using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Tag
	{
		AdmisInternalDataContext context;
		public Tbl_Tag(AdmisInternalDataContext pcontext = null)
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
		public int add(string Tag_Name,int File_Id,bool IsOrderConnected,int Time_Stamp_Id)
		{
			try{
				Tag objTag=new Tag();
				objTag.Tag_Name=Tag_Name;
				objTag.File_Id=File_Id;
				objTag.IsOrderConnected=IsOrderConnected;
				objTag.Time_Stamp_Id=Time_Stamp_Id;
				context.Tags.InsertOnSubmit(objTag);
				context.SubmitChanges();
				return objTag.Tags_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Tags_Id,string Tag_Name,int File_Id,bool IsOrderConnected,int Time_Stamp_Id)
		{
			try{
				Tag objTag = (from i in context.Tags where i.Tags_Id == Tags_Id select i).SingleOrDefault();
				if (objTag != null)
				{
					objTag.Tag_Name=Tag_Name;
					objTag.File_Id=File_Id;
					objTag.IsOrderConnected=IsOrderConnected;
					objTag.Time_Stamp_Id=Time_Stamp_Id;
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
		 public Tag selectOne(int Tags_Id)
		{
			try
			{
				return (from i in context.Tags where i.Tags_Id == Tags_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Tag> selectAll()
		{
			try
			{
				return (from i in context.Tags  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

