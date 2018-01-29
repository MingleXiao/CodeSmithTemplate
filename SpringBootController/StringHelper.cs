using System.IO;

public class StringHelper{

    public static string ToPascalCase(string srcStr){
        return ToPascalCase(srcStr,'_');
    }
    
    public static string ToPascalCase(string srcStr,char sep){
    
        if(srcStr==null || srcStr.Length==0)
        {
            return "";
        }
        
        string[] words=srcStr.Split(sep);
       
        string result="";
        string tempHead="";
        string tempBody="";
        string tempWord="";
        
        for(int i=0;i<words.Length;i++){
            tempHead="";
            tempBody="";
            tempWord="";
            
            if(words[i].Length==0){
                continue;
            }
            else{
                //取第一个字母为头部
                tempHead = words[i].Substring(0,1).ToUpper();//头部大写
                if(words[i].Length>1){
                    tempBody=words[i].Substring(1).ToLower();//身体小写
                }
                
                tempWord=tempHead+tempBody;
            }
            
            result+=tempWord;
        }
        
        return result;
    }
    
    public static string ToCamelCase(string srcStr){
        return  ToCamelCase(srcStr,'_');
    }
         
    public static string ToCamelCase(string srcStr,char sep){
        if(srcStr==null || srcStr.Length==0)
        {
            return "";
        }
        
        
        string result=ToPascalCase(srcStr,sep);
        if(result.Length==1){
            return result.Substring(0,1).ToLower();
        }
        else{
            return result.Substring(0,1).ToLower()+result.Substring(1);
        }
    }
    
    ///   get FunctionMemberVariableName ;get + 最后以首字母大写，其他小写；例：  COM_ID   getCom_id
    public static string getFunctionMemberVariableName( string FieldName)
    {
    	return "get" + ToPascalCase(FieldName);
    }
    
    ///   set FunctionMemberVariableName ;set +  最后以首字母大写，其他小写；例：  COM_ID   setCom_id
    public static string setFunctionMemberVariableName( string FieldName)
    {
    	return "set" + ToPascalCase(FieldName);
    }
}