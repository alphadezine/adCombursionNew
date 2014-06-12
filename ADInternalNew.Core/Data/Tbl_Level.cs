using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Level
	{
		AdmisInternalDataContext context;
		public Tbl_Level(AdmisInternalDataContext pcontext = null)
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
		public int add(string Level_Name)
		{
			try{
				Level objLevel=new Level();
				objLevel.Level_Name=Level_Name;
				context.Levels.InsertOnSubmit(objLevel);
				context.SubmitChanges();
				return objLevel.Level_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Level_Id,string Level_Name)
		{
			try{
				Level objLevel = (from i in context.Levels where i.Level_Id == Level_Id select i).SingleOrDefault();
				if (objLevel != null)
				{
					objLevel.Level_Name=Level_Name;
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
		 public Level selectOne(int Level_Id)
		{
			try
			{
				return (from i in context.Levels where i.Level_Id == Level_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Level> selectAll()
		{
			try
			{
				return (from i in context.Levels  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

