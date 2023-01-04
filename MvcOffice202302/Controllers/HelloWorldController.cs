using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcOffice.Controllers
{
    public class HelloWorldController : Controller
    {
//        ActionResult继承了IActionResult
//JsonResult、RedirectResult、FileResult、ViewResult、ContentResult均继承了ActionResult
//所以IActionResult类型的函数可以返回所有直接继承和间接继承他的类型数据
//而且每种数据支持两种返回方法
//   ----------------------------------------------
//　　类型 实例化对象               封装方法
//　　----------------------------------------------
//　　json结果 jsonresult json（Object）
　　
//　　跳转 RedirectResault Redirect（url）

//　　文件 FileResult File（）

//　　视图 ViewResault  View（）

//　　文本 ContentResault Context（“”）

//————————————————
//版权声明：本文为CSDN博主「A
//@abu」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
//原文链接：https://blog.csdn.net/weixin_39031283/article/details/107940940
        public IActionResult Index()
        {
            return View();
        }
        public string Welcome(string name,string numtimes)
        {
            // return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numtimes}");
            //增加判断 如果name与numtimes为空 则 要加如提示
            //if(name==""||numtimes=="")
            //if (name == string.Empty || numtimes == string.Empty)
            if (name == null || numtimes == "null")
            {
                return "请添加name以及numtimes的值,比如?name=wangwei&numtimes=6";
            }
            else { return "Hello  " + name + "  NumTimes is:" + numtimes; }
            

            
        }
    }
}
