public class NameHelper{

    /*
    RootOutputPath:	输出主目录
    ModulName:	模块名
    ActionName:动作
    Filename:文件名.java

    目录构造：输出主目录/模块名/动作/文件名.java


    处理逻辑：
    首先逐层判断 目录是否存在,不存在的话，创建目录
    */
    public string GetFileName(string RootOutputPath,string ModulName, string  ActionName,string Filename,string FileExtType )
    {
    	string RootOutputPathFormat = @"{0}";
    	string ModulNamePathFormat = @"{0}\{1}";
    	string ActionNamePathFormat = @"{0}\{1}\{2}";
    	string FilenameFormat = @"{0}\{1}\{2}\{3}.{4}";
    	
    	string FileName = "";

    	
    	string tmpPath = "";
        /// 1. 判断主路径是否存在,不存在创建主路径
    	tmpPath = string.Format(RootOutputPathFormat,RootOutputPath);
        
    	/// 判断主路径是否存在
        if(Directory.Exists(tmpPath) == false)
        {
            Directory.CreateDirectory(tmpPath);
        }
    	
    	/// 2 判断主路径下面的子路径是否存在
    	tmpPath = string.Format(ModulNamePathFormat,RootOutputPath,ModulName);
        
    	/// 判断主路径是否存在
        if(Directory.Exists(tmpPath) == false)
        {
            Directory.CreateDirectory(tmpPath);
        }
    	
    	/// 3 判断主路径下面的子路径的模块是否存在
    	tmpPath = string.Format(ActionNamePathFormat,RootOutputPath,ModulName,ActionName);
        
    	/// 判断主路径是否存在
        if(Directory.Exists(tmpPath) == false)
        {
            Directory.CreateDirectory(tmpPath);
        }
    	
    	/// 返回相应的文件名
    	FileName = 	string.Format(FilenameFormat,RootOutputPath,ModulName,ActionName,Filename,FileExtType);

    	return FileName;
    }
    	
    #region Naming 

    /// 输出 Model 的类名
    public string ModelName( string TableName)
    {
    	return ClassName(TableName);
    }

    /// 输出 Dao 的类名, 通用类名+DAOImpl
    public string DaoName( string TableName)
    {
    	return ClassName(TableName) + "DAOImpl";
    }

    /// 输出Action 的类名 通用类名+Action
    public string ActionName( string TableName)
    {
    	return ClassName(TableName) + "Action";
    }

    /// 输出 Manager 的类名 通用类名+ManagerImpl
    public string ManagerName( string TableName)
    {
    	return ClassName(TableName) + "ManagerImpl";
    }


    /// 输出 Form 的类名 通用类名+ManagerImpl
    public string FormName( string TableName)
    {
    	return ClassName(TableName) + "Form";
    }

    public string doName( string TableName)
    {
    	string tname = ClassName(TableName) + "doreport";
    	
    	return tname.ToLower();
    }

    public string DoName( string TableName)
    {
    	string tname = ClassName(TableName) + "Do";
    	
    	return tname.ToLower();
    }


    /// 输出 Manager 的类名 通用类名+ManagerImpl
    public string IntanceName( string TableName)
    {	
    	string tname = ClassName(TableName);
    	
    	string intanceName = tname.Substring(0,1).ToLower() +  tname.Substring(1);
    	
    	return intanceName;
    }


    /// 通过 字段名字 得到 通用的字段名字 ，最后以小写存在；例：  COM_ID   com_id
    public string ClassName( string TableName)
    {
    	string classname = StringUtil.ToPascalCase(TableName);
    	
    	return classname;
    }


    /// 通过 字段名字 得到 通用的字段名字 ，最后以小写存在；例：  COM_ID   com_id
    public string JspName( string TableName)
    {
    	string tname = ClassName(TableName);
    	
    	return tname.ToLower();
    }

    /// 通过 字段名字 得到 通用的字段名字 ，最后以小写存在；例：  COM_ID   com_id
    public string JspNameList( string TableName)
    {
    	string tname = ClassName(TableName)+"list";
    	
    	return tname.ToLower();
    }


    /// 通过 字段名字 得到 通用JSP页面  ，最后以小写存在；例：  COM_ID   com_id
    /// 

    public string JspNameInit( string TableName)
    {
    	string tname = ClassName(TableName)+"init";
    	
    	return tname.ToLower();
    }

    public string JspNameInitAdd( string TableName)
    {
    	string tname = ClassName(TableName)+"initadd";
    	
    	return tname.ToLower();
    }

    public string JspNameInitUpdate( string TableName)
    {
    	string tname = ClassName(TableName)+"initupdate";
    	
    	return tname.ToLower();
    }

    public string JspNameAdd( string TableName)
    {
    	string tname = ClassName(TableName)+"add";
    	
    	return tname.ToLower();
    }

    public string JspNameUpdate( string TableName)
    {
    	string tname = ClassName(TableName)+"update";
    	
    	return tname.ToLower();
    }

    public string JspNameRelaList( string TableName)
    {
    	string tname = ClassName(TableName)+"relalist";
    	
    	return tname.ToLower();
    }

    /// 通过 字段名字 得到 通用JSP 关页面  ，最后以小写存在；例：  COM_ID   com_id
    public string JspNameRelaMgr( string TableName)
    {
    	string tname = ClassName(TableName)+"relamgr";
    	
    	return tname.ToLower();
    }

    public string toCamel(string srcStr){
        return this.replaceUnderlineAndfirstToUpper(srcStr,"_","");
    }
    
    public string replaceUnderlineAndfirstToUpper(string srcStr, string org, string ob) {  
        String newString = "";  
        int first = 0;  
        while (srcStr.IndexOf(org) != -1) {  
            first = srcStr.IndexOf(org);  
            if (first != srcStr.Length) {  
                newString = newString + srcStr.Substring(0, first) + ob;  
                srcStr = srcStr.Substring(first + org.Length, srcStr.Length);  
                srcStr = firstCharacterToUpper(srcStr);  
            }  
        }  
        newString = newString + srcStr;  
        return newString;  
    }  
    
    public  string firstCharacterToUpper(String srcStr) {  
        return srcStr.Substring(0, 1).ToUpper() + srcStr.Substring(1);  
    } 
        



    #endregion

    /// 通过 字段名字 得到 通用的字段名字 ，最后以小写存在；例：  COM_ID   com_id
    public string GetMemberVariableName( string FieldName)
    {
    	string MemberVariableName = FieldName.ToLower() ;
    	
    	return MemberVariableName;
    }

    ///  通过 字段名字 得到 通用的字段名字 ，最后以首字母大写，其他小写；例：  COM_ID   Com_id
    public string GetFirstUpperMemberVariableName( string FieldName)
    {
    	string MemberVariableName =   FieldName.Substring(0,1).ToUpper() +  FieldName.Substring(1).ToLower();//   StringUtil.ToPascalCase(FieldName) ;
    	
    	return MemberVariableName;
    }
    
     

    ///   get FunctionMemberVariableName ;get + 最后以首字母大写，其他小写；例：  COM_ID   getCom_id
    public string getFunctionMemberVariableName( string FieldName)
    {
    	return "get" + ModelName(FieldName);
    }

    ///   set FunctionMemberVariableName ;set +  最后以首字母大写，其他小写；例：  COM_ID   setCom_id
    public string setFunctionMemberVariableName( string FieldName)
    {
    	return "set" + ModelName(FieldName);
    }

    public string GetFileName(string ClassName)
    {
    	return ClassName;
    }

    public string FormatDesc( string description )
    {
    	description = description.Replace("\r",string.Empty);
    	
    	description = description.Replace("\n",string.Empty);
    	
    	return description;
    }

    ///
    ///
    ///将*改成   各个字段 
    public string GetEtParam(TableSchema dt )
    {
    	string param = string.Empty;
    	
    	int count = 0;
    	/// {0} 变量 
    	string Format = "{0}";
    	foreach (ColumnSchema column in dt.Columns) 
    	{ 
    		if ( count == 0 )
    		{

    			param = column.Name ;
    		}
    		else
    		{
    			param = param + "," + column.Name;
    		}
    		count = count + 1;
    	}
    	
    	return param;
    }



    ///
    ///
    ///将*改成   各个字段 
    //根据采集数据的字段来  把自己加的字段字段去除掉
    public string GetEtParamSrc(TableSchema dt )
    {
    	string param = string.Empty;
    	
    	int count = 0;
    	/// {0} 变量 
    	string Format = "{0}";
    	foreach (ColumnSchema column in dt.Columns) 
    	{ 
    		if(column.Name == "B_TYPE")
    		{
    			break;
    		}
    		
    		if ( count == 0 )
    		{

    			param = column.Name ;
    		}
    		else
    		{
    			param = param + "," + column.Name;
    		}
    		count = count + 1;
    	}
    	
    	return param;
    }


    ///
    ///
    ///将*改成   各个字段 
    //根据采集数据的字段来  ?,?,?,?,?,?,?,?,?,?
    public string GetEtParamAsk(TableSchema dt )
    {
    	string param = string.Empty;
    	int count = 0;
    	/// {0} 变量 
    	foreach (ColumnSchema column in dt.Columns) 
    	{ 
    		if ( count == 0 )
    		{
    			param = "?" ;
    		}
    		else
    		{
    			param = param + "," + "?";
    		}
    		count = count + 1;
    	}
    	return param;
    }
}
